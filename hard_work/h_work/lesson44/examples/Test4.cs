public class DeactivatePersonSumSubDocumentsMessageHandlerTests
{
    private readonly DeactivatePersonSumSubDocumentsMessageHandler _handler;
    private readonly ISumSubDocumentImageStore _documentImageStore;
    public DeactivatePersonSumSubDocumentsMessageHandlerTests()
    {
        _handler = Mock.Resolve<DeactivatePersonSumSubDocumentsMessageHandler>();
        _documentImageStore = Mock.Resolve<ISumSubDocumentImageStore>();
    }
    
    [Fact]
    public async Task ShouldSave()
    {
        //Arrange
        var message = Fixture.Create<DeactivatePersonSumSubDocumentsMessage>();
        
        //Act
        await _handler.HandleMessage(message);
        
        //Assert
        await _documentImageStore.Received(1)
            .ChangePersonImagesActivation(Arg.Is<Guid>(g => g == message.PersonId), Arg.Is<bool>(b => b == false));
    }
}