namespace Application.Features.Job.Commands.UpdateJobBranchLocation
{
    public class UpdateJobBranchLocationCommandHandler : IRequestHandler<UpdateJobBranchLocationCommand, UpdateJobBranchLocationViewModel>
    {
        protected IMapper Mapper { get; }
        protected IUnitOfWork UnitOfWork { get; }

        public UpdateJobBranchLocationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<UpdateJobBranchLocationViewModel>> Handle(UpdateJobBranchLocationCommand request, CancellationToken cancellationToken)
        {
            string addressId = "";


            var currentJobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(request.JobBranchId);

            if (currentJobBranch == null) throw new BadRequestException();

            var currentAddress = await UnitOfWork.AddressRepository
                         .GetByPredicate(a => a.JobBranchId.Equals(currentJobBranch.Id));

            if (currentAddress is null)
            {
                #region ( Create New Address )
                var address = Mapper.Map<Address>(request.AddressViewModel);

                await UnitOfWork.AddressRepository.InsertAsync(address);
                await UnitOfWork.SaveAsync();


                var insertedAddress = await UnitOfWork.AddressRepository
                    .GetByPredicate(a => a.JobBranchId.Equals(currentJobBranch.Id));

                if (insertedAddress is null) throw new BadRequestException();

                addressId = insertedAddress.Id;
                currentAddress = insertedAddress;
                #endregion
            }
            else
            {
                addressId = currentAddress.Id;
            }

            var currentLocation = await UnitOfWork.LocationRepository
                .GetByPredicate(l => l.AddressId == addressId);

            if (currentLocation is null)
            {
                #region ( Create New Location )
                var location = Mapper.Map<Location>(request.LocationViewModel);

                await UnitOfWork.LocationRepository.InsertAsync(location);
                await UnitOfWork.SaveAsync();

                var insertedLocation = await UnitOfWork.LocationRepository
                    .GetByPredicate(a => a.AddressId.Equals(addressId));

                if (insertedLocation is null) throw new BadRequestException();

                currentLocation = location;
                #endregion
            }

            var updatedAddress = Mapper.Map(request.AddressViewModel, currentAddress);
            var updatedLocation = Mapper.Map(request.LocationViewModel, currentLocation);

            await UnitOfWork.AddressRepository.UpdateAsync(updatedAddress);
            await UnitOfWork.LocationRepository.UpdateAsync(updatedLocation);

            await UnitOfWork.SaveAsync();

            var result = new UpdateJobBranchLocationViewModel()
            {
                AddressViewModel = Mapper.Map<AddressViewModel>(updatedAddress),
                LocationViewModel = Mapper.Map<LocationViewModel>(updatedLocation),
                JobBranchId = currentJobBranch.Id
            };

            return result;
        }
    }
}