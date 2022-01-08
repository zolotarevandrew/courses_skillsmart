using AlgorithmsDataStructures;
using Xunit;

namespace PowerSet_14.Tests
{
    public partial class PowerSetTests
    {
        [Fact]
        public void Union_EmptySet2_ShouldReturnEmpty()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            //Act
            var res = set.Union(new PowerSet<string>());
            
            //Assert
            Assert.True(res.Size() == 0);
        }
        
        [Fact]
        public void Union_NotEmptyEmptySet2_ShouldReturnEmpty()
        {
            //Arrange
            var set = new PowerSet<string>();
            set.Put("1");
            
            //Act
            var res = set.Union(new PowerSet<string>());
            
            //Assert
            Assert.True(res.Size() == 1);
            Assert.True(res.Get("1"));
            Assert.False(res.Get("2"));
        }
        
        [Fact]
        public void Union_EqualSets_ShouldReturnSet()
        {
            //Arrange
            var set = new PowerSet<string>();
            set.Put("1");
            
            //Act
            var res = set.Union(set);
            Assert.Equal(1, res.Size());
            Assert.True(res.Get("1"));
        }
        
        [Fact]
        public void Union_PartiallyEqualSetsThreeElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new PowerSet<string>();
            set1.Put("1");
            set1.Put("2");
            set1.Put("3");
            
            var set2 = new PowerSet<string>();
            set2.Put("2");
            set2.Put("3");

            //Act
            var res = set1.Union(set2);
            Assert.Equal(3, res.Size());
            Assert.True(res.Get("2"));
            Assert.True(res.Get("3"));
            Assert.True(res.Get("1"));
            Assert.False(res.Get("5"));
        }
        
        [Fact]
        public void Union_NotEqualSetsThreeElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new PowerSet<string>();
            set1.Put("1");
            set1.Put("2");
            set1.Put("3");
            
            var set2 = new PowerSet<string>();
            set2.Put("4");
            set2.Put("6");

            //Act
            var res = set1.Union(set2);
            Assert.Equal(5, res.Size());
            Assert.True(res.Get("2"));
            Assert.True(res.Get("3"));
            Assert.True(res.Get("1"));
            Assert.True(res.Get("4"));
            Assert.True(res.Get("6"));
            Assert.False(res.Get("7"));
        }
        
        [Fact]
        public void Union_PartiallyEqualSetsTwentyAndTenThousandsElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new PowerSet<string>();
            for (int i = 0; i < PowerSetConsts.MaxSize; i++)
            {
                set1.Put(i.ToString());
            }
            
            var set2 = new PowerSet<string>();
            for (int i = 0; i < PowerSetConsts.MaxSize / 2; i++)
            {
                set2.Put(i.ToString());
            }

            //Act
            var res = set1.Union(set2);
            Assert.Equal(PowerSetConsts.MaxSize, res.Size());
            for (int i = 0; i < PowerSetConsts.MaxSize; i++)
            {
                Assert.True(res.Get(i.ToString()));
            }
        }
        
        [Fact]
        public void Union_EqualSetsTwentyThousandsElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new PowerSet<string>();
            for (int i = 0; i < PowerSetConsts.MaxSize; i++)
            {
                set1.Put(i.ToString());
            }
            
            var set2 = new PowerSet<string>();
            for (int i = 0; i < PowerSetConsts.MaxSize; i++)
            {
                set2.Put(i.ToString());
            }

            //Act
            var res = set1.Union(set2);
            Assert.Equal(PowerSetConsts.MaxSize, res.Size());
            for (int i = 0; i < PowerSetConsts.MaxSize; i++)
            {
                Assert.True(res.Get(i.ToString()));
            }
        }
        
        [Fact]
        public void Union_PartiallyEqualSetsTwoElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new PowerSet<string>();
            set1.Put("1");
            set1.Put("2");
            set1.Put("3");
            
            var set2 = new PowerSet<string>();
            set2.Put("2");
            set2.Put("3");
            
            //Act
            var res = set2.Union(set1);
            Assert.Equal(3, res.Size());
            Assert.True(res.Get("2"));
            Assert.True(res.Get("3"));
            Assert.True(res.Get("1"));
        }
    }
}