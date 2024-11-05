namespace h_work.lesson79;

public class Example4
{
    /*
     * public async Task Do() {
     *  var signature = new SumSubHookSignature(bodyArray, _config.WebhookSecretKey);
        
        var isCorrectSignature = signature.Value == request.Headers["x-payload-digest"];
        if (!isCorrectSignature)
        {
            _logger.LogWarning("Invalid webhook signature");
            return;
        }

        var contract = JsonConvert.DeserializeObject<WebhookRequest>(bodyJson);
        
        switch (contract.Type)
        {
            case "applicantReviewed":
            {
                await _publisher.PublishAsync(new CheckSumSubReviewMessage
                {
                    PersonId = externalUserId
                });
                break;
            }
        }
     * }
     */
}