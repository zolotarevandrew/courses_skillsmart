using h_work.lesson32.example3;

namespace h_work.lesson59.Example1;

/*
{
    public class Vehicle
    {
        public DateTime CreatedDate { get; private set; }
        public CarNumberValue Number { get; private set; }
        public VehicleSts Sts { get; set; }
        public VehiclePts Pts { get; set; }
        public EntityValue? Owner { get; set; }
        
        public bool IsMkadWeightByCoverage(Coverage coverage)
        {
            if (coverage == Coverage.MKAD)
            {
                if (string.IsNullOrEmpty(Sts.MaxWeight?.Value)) return false;
                var weight = int.Parse(Sts.MaxWeight.Value);
                return weight >= 3501 && weight <= 12000;
            }

            return false;
        }

        public bool IsBCategoryMore3Years
        {
            get
            {
                if (Sts.Category.Count == 0) return false;
                
                var ptsYear = Pts.IssueYear;
                if (ptsYear == null) return false;

                var category = Sts.Category[0].Name;
                var year = int.Parse(ptsYear.Value);
                var now = DateTime.UtcNow.ToMsk();
                var nowYear = now.Year;
                return category == "B" && year <= (nowYear -3);
            }
        }
        
        public bool IsCCategoryYear2022
        {
            get
            {
                if (Sts.Category.Count == 0) return false;
                
                var ptsYear = Pts.IssueYear;
                if (ptsYear == null) return false;

                var category = Sts.Category[0].Name;
                var year = int.Parse(ptsYear.Value);
                return category == "C" && year == 2022;
            }
        }
        
        public bool IsCCategoryMonthDiffLess12(DateTime passDate)
        {
            if (Sts.Category.Count == 0) return false;
                
            var ptsDate = Pts.IssueDate;
            if (string.IsNullOrEmpty(ptsDate?.Value)) return false;

            var category = Sts.Category[0].Name;
            var date = ptsDate.Value.ToDate().Value;
            var monthDiff = passDate.GetMonthDifference(date);
            return category == "C" && monthDiff < 12;
        }
        
        public bool IsCCategoryMonthDiffGreater12(DateTime passDate)
        {
            if (Sts.Category.Count == 0) return false;
                
            var ptsDate = Pts.IssueDate;
            if (string.IsNullOrEmpty(ptsDate?.Value)) return false;

            var category = Sts.Category[0].Name;
            var date = ptsDate.Value.ToDate().Value;
            var monthDiff = passDate.GetMonthDifference(date);
            return category == "C" && monthDiff > 12;
        }
        
        public bool IsCCategoryOlderCurrentYear
        {
            get
            {
                if (Sts.Category.Count == 0) return false;
                
                var ptsYear = Pts.IssueYear;
                if (ptsYear == null) return false;

                var category = Sts.Category[0].Name;
                var year = int.Parse(ptsYear.Value);
                var now = DateTime.UtcNow.ToMsk();
                var nowYear = now.Year;
                return category == "C" && year < nowYear;
            }
        }

        public bool IsBCategoryLess3Years
        {
            get
            {
                if (Sts.Category.Count == 0) return false;
                
                var ptsYear = Pts.IssueYear;
                if (ptsYear == null) return false;

                var category = Sts.Category[0].Name;
                var year = int.Parse(ptsYear.Value);
                return category == "B" && (year is 2022 or 2021 or 2020);
            }
        }
        
        public bool IsBCategory2019(DateTime passDate)
        {
            if (Sts.Category.Count == 0) return false;
                
            var ptsDate = Pts.IssueDate;
            if (string.IsNullOrEmpty(ptsDate?.Value)) return false;

            var category = Sts.Category[0].Name;
            var date = ptsDate.Value.ToDate()!.Value;
            var monthDiff = passDate.GetMonthDifference(date);
            return category == "B" && monthDiff > 36;
        }
        
        public bool IsBCategoryLess36Month(DateTime passDate)
        {
            if (Sts.Category.Count == 0) return false;
                
            var ptsDate = Pts.IssueDate;
            if (string.IsNullOrEmpty(ptsDate?.Value)) return false;

            var category = Sts.Category[0].Name;
            var date = ptsDate.Value.ToDate()!.Value;
            var monthDiff = passDate.GetMonthDifference(date);
            return category == "B" && monthDiff < 36;
        }
    }
}
*/
