using System.Collections.Generic;
using AlgorithmsDataStructures;
using Xunit;

namespace PowerSet_14.Tests
{
    public class HashSetTests
    {
        [Fact]
        public void IsSubsetOf_EmptySet2_ShouldReturnTrue()
        {
            //Arrange
            var set = new HashSet<string>();
            
            Assert.True(set.IsSubsetOf(set));
        }
        
        [Fact]
        public void IsSubsetOf_NotEmptyEmptySet2_ShouldReturnEmpty()
        {
            //Arrange
            var set = new HashSet<string>();
            set.Add("1");

            var set2 = new HashSet<string>();
            
            Assert.False(set.IsSubsetOf(set2));
            Assert.True(set2.IsSubsetOf(set));
        }
        
        [Fact]
        public void IsSubsetOf_EqualSets_ShouldReturnSet()
        {
            //Arrange
            var set = new HashSet<string>();
            set.Add("1");
            
            //Act
            var res = set.IsSubsetOf(set);
            Assert.True(res);
        }
        
        [Fact]
        public void IsSubsetOf_PartiallyEqualSetsOneElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new HashSet<string>();
            set1.Add("1");
            
            var set2 = new HashSet<string>();
            set2.Add("2");

            //Act
            Assert.False(set1.IsSubsetOf(set2));
            Assert.False(set2.IsSubsetOf(set1));
        }
        
        [Fact]
        public void IsSubsetOf_PartiallyEqualSetsThreeElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new HashSet<string>();
            set1.Add("1");
            set1.Add("2");
            set1.Add("3");
            set1.Add("4");
            set1.Add("5");
            set1.Add("6");
            
            var set2 = new HashSet<string>();
            set2.Add("1");
            set2.Add("2");

            //Act
            Assert.True(set2.IsSubsetOf(set1));
            Assert.False(set1.IsSubsetOf(set2));
        }
        
        [Fact]
        public void IsSubsetOf_PartiallyEqualSetsThreeElements2_ShouldReturnSet()
        {
            //Arrange
            var set1 = new HashSet<string>();
            set1.Add("1");
            set1.Add("2");
            set1.Add("3");
            set1.Add("4");
            set1.Add("5");
            set1.Add("6");
            
            var set2 = new HashSet<string>();
            set2.Add("1");
            set2.Add("2");

            //Act
            var res = set1.IsSubsetOf(set2);
            Assert.False(res);
        }
        
        [Fact]
        public void IsSubsetOf_EqualSets5Elements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new HashSet<string>();
            set1.Add("1");
            set1.Add("2");
            set1.Add("3");
            set1.Add("4");
            set1.Add("5");
            
            var set2 = new HashSet<string>();
            set2.Add("1");
            set2.Add("2");
            set2.Add("3");
            set2.Add("4");
            set2.Add("5");

            //Act
            Assert.True(set1.IsSubsetOf(set2));
            Assert.True(set2.IsSubsetOf(set1));
        }
        
        [Fact]
        public void IsSubsetOf_NotEqualSetsThreeElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new HashSet<string>();
            set1.Add("1");
            set1.Add("2");
            set1.Add("3");
            
            var set2 = new HashSet<string>();
            set2.Add("4");
            set2.Add("6");

            //Act
            Assert.False(set1.IsSubsetOf(set2));
            Assert.False(set2.IsSubsetOf(set1));
        }
        
        [Fact]
        public void IsSubsetOf_NotEqualSetsThreeElements2_ShouldReturnSet()
        {
            //Arrange
            var set1 = new HashSet<string>();
            set1.Add("1");
            set1.Add("2");
            set1.Add("3");
            
            var set2 = new HashSet<string>();
            set2.Add("1");
            set2.Add("6");

            //Act
            Assert.False(set1.IsSubsetOf(set2));
            Assert.False(set2.IsSubsetOf(set1));
        }
        
        [Fact]
        public void IsSubsetOf_PartiallyEqualSetsTwentyAndTenThousandsElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new HashSet<string>();
            for (int i = 0; i < PowerSetConsts.MaxSize; i++)
            {
                set1.Add(i.ToString());
            }
            
            var set2 = new HashSet<string>();
            for (int i = 0; i < PowerSetConsts.MaxSize / 2; i++)
            {
                set2.Add(i.ToString());
            }

            //Act
            Assert.True(set2.IsSubsetOf(set1));
            Assert.False(set1.IsSubsetOf(set2));
        }
        
        [Fact]
        public void IsSubsetOf_EqualSetsTwentyThousandsElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new HashSet<string>();
            for (int i = 0; i < PowerSetConsts.MaxSize; i++)
            {
                set1.Add(i.ToString());
            }
            
            var set2 = new HashSet<string>();
            for (int i = 0; i < PowerSetConsts.MaxSize; i++)
            {
                set2.Add(i.ToString());
            }

            //Act
            Assert.True(set1.IsSubsetOf(set2));
            Assert.True(set2.IsSubsetOf(set1));
        }
        
        [Fact]
        public void IsSubsetOf_PartiallyEqualSetsTwoElements_ShouldReturnSet()
        {
            //Arrange
            var set1 = new HashSet<string>();
            set1.Add("2");
            set1.Add("3");
            
            var set2 = new HashSet<string>();
            set2.Add("1");
            set2.Add("2");
            set2.Add("3");
            
            //Act
            var res = set1.IsSubsetOf(set2);
            Assert.True(res);
            
            res = set2.IsSubsetOf(set1);
            Assert.False(res);
        }
    }
}