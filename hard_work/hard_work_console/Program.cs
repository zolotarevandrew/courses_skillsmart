using h_work.lesson33;

var id = Guid.NewGuid();
var user1 = new User
{
    Id = id,
    FirstName = "first",
    LastName = "last"
};
var user2 = new User
{
    Id = id,
    FirstName = "first",
    LastName = "last"
};
var hashCode = user1.GetHashCode();
var hashCode2 = user2.GetHashCode();
var a = hashCode2;