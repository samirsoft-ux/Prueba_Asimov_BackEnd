using Asimov.API.Directors.Domain.Repositories;
using Asimov.API.Security.Authorization.Handlers.Interfaces;
using Asimov.API.Shared.Domain.Repositories;
using Asimov.API.Teachers.Domain.Models;
using Asimov.API.Teachers.Domain.Repositories;
using Asimov.API.Teachers.Services;
using AutoMapper;
using Moq;
using NUnit.Framework;

namespace Asimov.API.Unit.Test;

public class AddTeacherUTest
{
    private static Mock<ITeacherRepository> GetDefaultITeacherRepositoryInstance()
    {
        return new Mock<ITeacherRepository>();
    }

    private static Mock<IDirectorRepository> GetDefaultIDirectorRepositoryInstance()
    {
        return new Mock<IDirectorRepository>();
    }
    private static Mock<IJwtHandler> GetDefaultIJwtHandlerInstance()
    {
        return new Mock<IJwtHandler>();
    }
    private static Mock<IMapper> GetDefaultIMapperInstance()
    {
        return new Mock<IMapper>();
    }
    private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
    {
        return new Mock<IUnitOfWork>();
    }
    
    [Test]
    public async Task AddTeachersToThings()
    { 
        //Arrange
        var mockTeacherRepository = GetDefaultITeacherRepositoryInstance();
        mockTeacherRepository.Setup(service => service.ListAsync()).ReturnsAsync(new List<Teacher>());
        var mockMockDirectorRepository = GetDefaultIDirectorRepositoryInstance();
        var mockJwtHandler = GetDefaultIJwtHandlerInstance();
        var mockMapper = GetDefaultIMapperInstance();
        
        var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
        
        var service = new TeacherService(mockTeacherRepository.Object,
            mockMockDirectorRepository.Object,
            mockUnitOfWork.Object,
            mockJwtHandler.Object,mockMapper.Object
            );
        
        //Act
        var result = (List<Teacher>)await service.ListAsync();
        var activityCount = result.Count;
        //Assert
        Assert.That(activityCount, Is.EqualTo(0));
    }
}