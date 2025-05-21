using Domain.Entities.Comment;
using ViewModels.AdminPanel.Comment;

namespace Admin.MVC.Controllers;

public class CommentController(IUnitOfWork unitOfWork, IMapper mapper) : BaseController
{
    #region ( DI )
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IMapper Mapper { get; } = mapper;
    #endregion

    #region ( Index )
    [HttpGet]
    public IActionResult Index(CommentFilterViewModel filter)
    {
        var comments = UnitOfWork.CommentRepository.GetByFilter(filter);

        return View(comments);
    }
    #endregion

    #region ( Delete )
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var comment = await UnitOfWork.CommentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        try
        {
            await UnitOfWork.CommentRepository.DeleteAsync(comment);
            await UnitOfWork.SaveAsync();
        }
        catch (Exception exception)
        {
            ErrorAlert(exception.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion

    #region ( Update )
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var comment = await UnitOfWork.CommentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        var model = Mapper.Map<UpdateCommentViewModel>(comment);

        return PartialView("_Update", model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCommentViewModel updateCommentViewModel)
    {
        if (!ModelState.IsValid)
        {
            #region ( Client Error )
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
            #endregion

            return RedirectToAction("Index");
        }

        var comment = await UnitOfWork.CommentRepository.GetByIdAsync(updateCommentViewModel.Id);

        if (comment == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        comment = Mapper.Map(updateCommentViewModel, comment);

        await UnitOfWork.CommentRepository.UpdateAsync(comment);

        try
        {
            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch (Exception ex)
        {
            ErrorAlert(ex.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion

    #region ( Detail )
    [HttpGet]
    public async Task<IActionResult> Detail(int id)
    {
        var comment = await UnitOfWork.CommentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            ErrorAlert("کامنت یافت نشد!");

            return RedirectToAction("Index");
        }

        return PartialView("_Detail", comment);
    }
    #endregion


    //Answers
    #region ( Create Answer Comment )
    [HttpGet]
    public async Task<IActionResult> CreateAnswerComment(int id)
    {
        var comment = await UnitOfWork.CommentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            ErrorAlert("کامنت یافت نشد!");

            return RedirectToAction("Index");
        }

        ViewData["commentId"] = comment.Id;

        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        ViewData["userIp"] = ipAddress;

        return PartialView("_CreateAnswerComment");
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnswerComment(CreateAnswerCommentViewModel createAnswerCommentViewModel)
    {
        if (!ModelState.IsValid)
        {
            #region ( Client Error )
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
            #endregion

            return RedirectToAction("Index");
        }

        var answerComment = Mapper.Map<AnswerComment>(createAnswerCommentViewModel);

        await UnitOfWork.AnswerCommentRepository.InsertAsync(answerComment);

        try
        {
            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch (Exception ex)
        {
            ErrorAlert(ex.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion

    #region ( Watch Answers )
    [HttpGet]
    public async Task<IActionResult> WatchAnswers(int id)
    {
        var answerComments = await UnitOfWork.AnswerCommentRepository.GetAllAsync(c => c.CommentId == id);

        return PartialView("_WatchAnswers", answerComments);
    }
    #endregion

    #region ( Update )
    [HttpGet]
    public async Task<IActionResult> UpdateAnswer(int id)
    {
        var comment = await UnitOfWork.AnswerCommentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        var model = Mapper.Map<UpdateAnswerCommentViewModel>(comment);

        return PartialView("_UpdateAnswer", model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAnswer(UpdateAnswerCommentViewModel updateAnswerCommentViewModel)
    {
        if (!ModelState.IsValid)
        {
            #region ( Client Error )
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
            #endregion

            return RedirectToAction("Index");
        }

        var answerComment = await UnitOfWork.AnswerCommentRepository.GetByIdAsync(updateAnswerCommentViewModel.Id);

        if (answerComment == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        answerComment = Mapper.Map(updateAnswerCommentViewModel, answerComment);

        await UnitOfWork.AnswerCommentRepository.UpdateAsync(answerComment);

        try
        {
            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch (Exception ex)
        {
            ErrorAlert(ex.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion

    #region ( Delete Answer )
    [HttpGet]
    public async Task<IActionResult> DeleteAnswer(int id)
    {
        var comment = await UnitOfWork.AnswerCommentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        try
        {
            await UnitOfWork.AnswerCommentRepository.DeleteAsync(comment);
            await UnitOfWork.SaveAsync();
        }
        catch (Exception exception)
        {
            ErrorAlert(exception.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion


    #region ( Set Comment Status )
    [HttpPost]
    public async Task<IActionResult> SetStatus(int id, bool status)
    {
        var comment = await UnitOfWork.CommentRepository.GetByIdAsync(id);

        if (comment == null)
        {
            ErrorAlert("کامنت یافت نشد!");

            return RedirectToAction("Index");
        }

        comment.IsConfirmed = status;

        await UnitOfWork.CommentRepository.UpdateAsync(comment);

        try
        {
            await UnitOfWork.SaveAsync();

            SuccessAlert();

            return RedirectToAction("Index");
        }
        catch (Exception exception)
        {
            ErrorAlert(exception.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion
}