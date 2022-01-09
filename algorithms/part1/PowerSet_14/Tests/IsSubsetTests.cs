using AlgorithmsDataStructures;
using Xunit;

namespace PowerSet_14.Tests
{
    public partial class PowerSetTests
    {
        [Fact]
        public void IsSubset_EmptySet2_ShouldReturnTrue()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            Assert.True(set.IsSubset(set));
        }
        
        [Fact]
        public void IsSubset_NotEmptyEmptySet2_ShouldReturnEmpty()
        {
            //Arrange
            var set = new PowerSet<string>();
            set.Put("1");

            var set2 = new PowerSet<string>();
            
            Assert.True(set.IsSubset(set2));
            Assert.False(set2.IsSubset(set));
        }
        
        [Fact]
        public void IsSubset_EqualSets_ShouldReturnSet()
        {
            //Arrange
            var set = new PowerSet<string>();
            set.Put("1");
            
            //Act
            var res = set.IsSubset(set);
            Assert.True(res);
        }
        
        [Fact]
        public void IsSubset_PartiallyEqualSetsOneElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new PowerSet<string>();
            set1.Put("1");
            
            var set2 = new PowerSet<string>();
            set2.Put("2");

            //Act
            Assert.False(set1.IsSubset(set2));
            Assert.False(set2.IsSubset(set1));
        }
        
        [Fact]
        public void IsSubset_PartiallyEqualSetsThreeElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new PowerSet<string>();
            set1.Put("1");
            set1.Put("2");
            set1.Put("3");
            set1.Put("4");
            set1.Put("5");
            set1.Put("6");
            
            var set2 = new PowerSet<string>();
            set2.Put("1");
            set2.Put("2");

            //Act
            Assert.True(set1.IsSubset(set2));
            Assert.False(set2.IsSubset(set1));
        }

        [Fact]
        public void IsSubset_EqualSets5Elements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new PowerSet<string>();
            set1.Put("1");
            set1.Put("2");
            set1.Put("3");
            set1.Put("4");
            set1.Put("5");
            
            var set2 = new PowerSet<string>();
            set2.Put("1");
            set2.Put("2");
            set2.Put("3");
            set2.Put("4");
            set2.Put("5");

            //Act
            Assert.True(set1.IsSubset(set2));
            Assert.True(set2.IsSubset(set1));
        }
        
        [Fact]
        public void IsSubset_NotEqualSetsThreeElements_ShouldReturnSet()
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
            Assert.False(set1.IsSubset(set2));
            Assert.False(set2.IsSubset(set1));
        }
        
        [Fact]
        public void IsSubset_NotEqualSetsThreeElements2_ShouldReturnSet()
        {
            //Arrange
            var set1 = new PowerSet<string>();
            set1.Put("1");
            set1.Put("2");
            set1.Put("8");
            set1.Put("3");
            
            var set2 = new PowerSet<string>();
            set2.Put("1");
            set2.Put("6");

            //Act
            Assert.False(set1.IsSubset(set2));
            Assert.False(set2.IsSubset(set1));
        }
        
        [Fact]
        public void IsSubset_PartiallyEqualSetsTwentyAndTenThousandsElements_ShouldReturnSet()
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
            Assert.True(set1.IsSubset(set2));
            Assert.False(set2.IsSubset(set1));
        }
        
        [Fact]
        public void IsSubset_EqualSetsTwentyThousandsElements_ShouldReturnSet()
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
            Assert.True(set1.IsSubset(set2));
            Assert.True(set2.IsSubset(set1));
        }
        
        [Fact]
        public void IsSubset_PartiallyEqualSetsTwoElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new PowerSet<string>();
            set1.Put("2");
            set1.Put("3");
            
            var set2 = new PowerSet<string>();
            set2.Put("1");
            set2.Put("2");
            set2.Put("3");
            
            //Act
            Assert.True(set2.IsSubset(set1));
            Assert.False(set1.IsSubset(set2));
        }
    }
}