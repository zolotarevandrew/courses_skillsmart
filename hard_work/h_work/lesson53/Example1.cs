namespace h_work.lesson53;

/*
public class Example1
{
    
    public async Task<PassFiltersResponse> GetFilteredAsync(FilterRequest request)
    {
        var textSearch = request.TextSearch;
        var search = _collection
            .Aggregate()
            .Match(x => textSearch == null || x.CarNumber.ToLowerInvariant().Contains(textSearch.ToLowerInvariant()));

        var status = request.GetFilter(FiltersConsts.Pass.Status);
        if (status?.Length > 0)
        {
            string[] statusArr = status;
            var statusValues = statusArr.Select(c => int.Parse(c));
            var filter = Builders<ApplyForPass>.Filter.AnyIn("status", statusValues);
            search = search.Match(filter);
        }
            
        var applicants = request.GetFilter(FiltersConsts.Pass.Applicant);
        if (applicants?.Length > 0)
        {
            var filter = Builders<ApplyForPass>.Filter.AnyIn("applicant._id", applicants);
            search = search.Match(filter);
        }
            
        var remote = request.GetFilter(FiltersConsts.Pass.Remote);
        if (remote?.Value != null)
        {
            var filter = Builders<ApplyForPass>.Filter.Eq("status", ApplyForPassStatus.Remote);
            search = search.Match(filter);   
        }
            
        var digitalSign = request.GetFilter(FiltersConsts.Pass.DigitalSign);
        if (digitalSign?.Value != null)
        {
            var filter = Builders<ApplyForPass>.Filter.Ne("status", ApplyForPassStatus.Remote);
            search = search.Match(filter);   
        }
    }
    
}
*/