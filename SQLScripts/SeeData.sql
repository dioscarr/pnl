
select * from Dependent

select 
 Person.FirstName + ' ' + Person.LastName As Name, taxforms.TaxYear,  Questions.TheQuestion, Answers.TheAnswer, Address.State,Address.Zip,FormSteps.TheStep,FormSteps.Section,FormSteps.SectionName
from TaxForms
join Person on Person.id = TaxForms.PersonID
join Address on address.PersonID = Person.id
join answers on answers.taxformid = taxforms.id
join questions on questions.id = answers.questionid
join FormSteps on FormSteps.id = questions.FormStepId

