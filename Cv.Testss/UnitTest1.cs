using AutoMapper;
using CvMaker.Core.Enums;
using CvMaker.Core.Models;
using CvMaker.Web;
using CvMaker.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MappingTests
{
    private IMapper _mapper;

    [TestInitialize]
    public void Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        _mapper = config.CreateMapper();
    }

    [TestMethod]
    public void Test_CurriculumVitae_To_CvItemModel_Mapping()
    {
        // Arrange
        var curriculumVitae = new CurriculumVitae
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = "123456789",
            Email = "john.doe@example.com",
            Languages = new List<LanguageKnowledge>
            {
                new LanguageKnowledge { Language = "English", LanguageLevel = KnowledgeEnum.Beginner },
                new LanguageKnowledge { Language = "French", LanguageLevel = KnowledgeEnum.Excellent }
            },
            Skills = new List<Skills>
            {
                new Skills { SkillName = "C#", SkillDescription= "Advanced" },
                new Skills {SkillName = "JavaScript", SkillDescription = "Intermediate"}
            },
            Educations = new List<Education>
            {
                new Education { EducationalLevel = "Bachelor's", NameOfSchool= "Example University", StudyStartDate= DateTime.Now }
            },
            Employments = new List<Employment>
            {
                new Employment { NameOfCompany = "Example Company", JobPosition= "Software Engineer", StartDate= DateTime.Now.AddDays(-3)}
            },
            Address = new Address
            {
                PostCode = "12345",
                City = "Example City",
                Street = "123 Street",
                Country = "Example Country",
                StreetNumber = "A-1"
            }
        };

        // Act
        var cvItemModel = _mapper.Map<CurriculumVitae, CvItemModel>(curriculumVitae);

        // Assert
        Assert.AreEqual(curriculumVitae.Id, cvItemModel.Id);
        Assert.AreEqual(curriculumVitae.FirstName, cvItemModel.Name);
        Assert.AreEqual(curriculumVitae.LastName, cvItemModel.LastName);
        Assert.AreEqual(curriculumVitae.PhoneNumber, cvItemModel.PhoneNumber);
        Assert.AreEqual(curriculumVitae.Email, cvItemModel.Email);

        // Assert LanguageKnowledge
        Assert.AreEqual(curriculumVitae.Languages.Count, cvItemModel.LanguageKnowledge.Count);
        Assert.AreEqual(curriculumVitae.Languages.First().Language, cvItemModel.LanguageKnowledge.First().Language);
        Assert.AreEqual(curriculumVitae.Languages.First().LanguageLevel, cvItemModel.LanguageKnowledge.First().LanguageLevel);

        // Assert Skills
        Assert.AreEqual(curriculumVitae.Skills.Count, cvItemModel.Skills.Count);
        Assert.AreEqual(curriculumVitae.Skills.First().SkillName, cvItemModel.Skills.First().SkillName);
        Assert.AreEqual(curriculumVitae.Skills.First().SkillDescription, cvItemModel.Skills.First().SkillDescription);

        // Assert Educations
        Assert.AreEqual(curriculumVitae.Educations.Count, cvItemModel.Educations.Count);
        Assert.AreEqual(curriculumVitae.Educations.First().EducationalLevel, cvItemModel.Educations.First().EducationalLevel);
        Assert.AreEqual(curriculumVitae.Educations.First().NameOfSchool, cvItemModel.Educations.First().NameOfSchool);
        Assert.AreEqual(curriculumVitae.Educations.First().StudyStartDate, cvItemModel.Educations.First().StudyStartDate);

        // Assert Employments
        Assert.AreEqual(curriculumVitae.Employments.Count, cvItemModel.Employments.Count);
        Assert.AreEqual(curriculumVitae.Employments.First().NameOfCompany, cvItemModel.Employments.First().NameOfCompany);
        Assert.AreEqual(curriculumVitae.Employments.First().JobPosition, cvItemModel.Employments.First().JobPosition);
        Assert.AreEqual(curriculumVitae.Employments.First().StartDate, cvItemModel.Employments.First().StartDate);

        // Assert Address
        Assert.AreEqual(curriculumVitae.Address.PostCode, cvItemModel.Address.PostCode);
        Assert.AreEqual(curriculumVitae.Address.City, cvItemModel.Address.City);
        Assert.AreEqual(curriculumVitae.Address.Street, cvItemModel.Address.Street);
        Assert.AreEqual(curriculumVitae.Address.Country, cvItemModel.Address.Country);
        Assert.AreEqual(curriculumVitae.Address.StreetNumber, cvItemModel.Address.StreetNumber);
    }

    [TestMethod]
    public void Test_Address_To_AddressViewModel_Mapping()
    {
        // Arrange
        var address = new Address
        {
            PostCode = "12345",
            City = "Example City",
            Street = "123 Street",
            Country = "Example Country",
            StreetNumber = "A-1",
            CurriculumVitaeId = 1
        };

        // Act
        var addressViewModel = _mapper.Map<Address, AddressViewModel>(address);

        // Assert
        Assert.AreEqual(address.PostCode, addressViewModel.PostCode);
        Assert.AreEqual(address.City, addressViewModel.City);
        Assert.AreEqual(address.Street, addressViewModel.Street);
        Assert.AreEqual(address.Country, addressViewModel.Country);
        Assert.AreEqual(address.StreetNumber, addressViewModel.StreetNumber);
        Assert.AreEqual(address.CurriculumVitaeId, addressViewModel.CurriculumVitaeId);
    }
}
