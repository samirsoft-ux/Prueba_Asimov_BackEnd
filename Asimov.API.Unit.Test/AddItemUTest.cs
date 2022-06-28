using Asimov.API.Courses.Domain.Repositories;
using Asimov.API.Items.Domain.Models;
using Asimov.API.Items.Domain.Repositories;
using Asimov.API.Items.Services;
using Asimov.API.Shared.Domain.Repositories;
using Moq;
using NUnit.Framework;

namespace Asimov.API.Unit.Test;

public class AddItemUTest
{
    private static Mock<IItemRepository> GetDefaultIItemRepositoryInstance()
    {
        return new Mock<IItemRepository>();
    }
    private static Mock<ICourseRepository> GetDefaultICourseRepositoryInstance()
    {
        return new Mock<ICourseRepository>();
    }
    private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
    {
        return new Mock<IUnitOfWork>();
    }
    [Test]
    public async Task AddItemsToThings()
    { 
        //Arrange
        var mockItemRepository = GetDefaultIItemRepositoryInstance();
        mockItemRepository.Setup(service => service.ListAsync()).ReturnsAsync(new List<Item>());
        var mockMockRepositoryInstance = GetDefaultICourseRepositoryInstance();
        var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
        
        var service = new ItemService(mockItemRepository.Object,mockMockRepositoryInstance.Object, mockUnitOfWork.Object);
        
        //Act
        var result = (List<Item>)await service.ListAsync();
        var activityCount = result.Count;
        //Assert
        Assert.That(activityCount, Is.EqualTo(0));
    }
}