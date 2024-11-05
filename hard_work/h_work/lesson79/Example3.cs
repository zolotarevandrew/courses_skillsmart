namespace h_work.lesson79;

public class Example3
{
    /*
     public async Task<Result<string>> CreateAsync(DriverNumberValue number, DriverSerialValue serial)
        {
            var driver = new Driver(number, serial);

            var foundDuplicate = await _repository.GetByLicenseAsync(driver.License);
            if (foundDuplicate != null) return Result<string>.Failed("Водитель с таким удостоверением уже существует");

            var newDriver = await CreateInternalAsync(driver);
            return Result<string>.Ok(newDriver.Id);
        }
     */
}