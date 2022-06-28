using Asimov.API.Competences.Domain.Models;
using Asimov.API.Competences.Domain.Repositories;
using Asimov.API.Competences.Services;
using Asimov.API.Shared.Domain.Repositories;
using Moq;
using NUnit.Framework;

namespace Asimov.API.Unit.Test;

public class AddCompetenceUTest
{ 
    private static Mock<ICompetenceRepository> GetDefaultICompetenceRepositoryInstance()
    {
        return new Mock<ICompetenceRepository>();
    }
    private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
    {
        return new Mock<IUnitOfWork>();
    }
    [Test]
    public async Task AddCompetencesToThings()
    { 
        //Arrange
        var mockCompetenceRepository = GetDefaultICompetenceRepositoryInstance();
        mockCompetenceRepository.Setup(service => service.ListAsync()).ReturnsAsync(new List<Competence>());
        var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
        var service = new CompetenceService(mockCompetenceRepository.Object, mockUnitOfWork.Object);
        
        //Act
        var result = (List<Competence>)await service.ListAsync();
        var activityCount = result.Count;
        //Assert
        Assert.That(activityCount, Is.EqualTo(0));
    }
}