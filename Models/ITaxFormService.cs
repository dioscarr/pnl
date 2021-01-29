using pnl.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pnl.Models
{
    public interface ITaxFormService
    {
        Task<Dependent> AddDependentAsync(Dependent model);
        (int, string) CheckIfCurrentTaxYearExist();
        Task<TaxForm> CheckIfTaxExist(int TaxYear);
        Task<TaxForm> CreateNewTaxFormAsync(int TaxYear);
        List<Dependent> DeleteDependents(List<Dependent> model, int TaxFormId);
        List<Answer> GetAnswers(int taxFormId, int stepnumber);
        DependentCareProviders GetCareProviderIfExist(int TaxFormID);
        List<ToggleMe> GetCriteriaOptions();
        Person GetCurrentUser(int TaxFormID);
        Address GetCurrentUserAddress(int taxFormId);
        List<Dependent> GetDependets(int TaxFormID);
        List<FilingStatus> GetfilingStatuses();
        List<FormStep> GetFormStep(int TheStep);
        List<Question> GetQuestions(int FormStepId);
        ReportData GetReport(int taxFormId);
        List<state> GetStates();
        void GetSummary(int id);
        TaxForm GetTaxForm(int TaxFormID);
        List<TaxFormCriteria> GetTaxFormCriteria(int TaxFormId);
        (List<int>, List<TaxForm>) GetTaxYears(int NumberOfPreviousYears = 20);
        (List<int>, List<TaxForm>, List<TaxForm>) GetTaxYearsAndArchived(int NumberOfPreviousYears = 20);
        bool SubmitReview(int TaxFormId);
        void SaveAndReview(int TaxFormId);
        DependentCareProviders SaveCareProvider(DependentCareProviders model);
        void SaveProgressStep2(int TaxFormId, int Step, Step2VM CurrentStep);
        void SaveProgressStep3(List<Answer> answers);
        Task<List<ToggleMe>> SaveSelectedCriteriasAsync(List<ToggleMe> model, int TaxFormId);
        Person SaveTaxFormCurrentUserInfo(Person model, int TaxFormID);
        bool SubmitTaxForm(int taxFormId);
        bool UpdateCurrentUser(Person model);
    }
}