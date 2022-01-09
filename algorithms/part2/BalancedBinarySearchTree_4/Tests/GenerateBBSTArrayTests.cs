using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Xunit;

namespace BalancedBinarySearchTree_4.Tests
{
    public class GenerateBBSTArrayTests
    {
        [Fact]
        public void GenerateBBSTArray_8Elements_ShouldBeBalancedTree()
        {
            //Arrange
            var input = new List<int>(8)
            {
                8, 7, 6, 5, 4, 3, 2, 1
            };

            //Act
            var res = BalancedBST.GenerateBBSTArray(input.ToArray());
            
            //Assert
            AssertArray(res, new List<int> { 5, 3, 7, 2, 4, 6, 8, 1 });
        }
        
        [Fact]
        public void GenerateBBSTArray_7Elements_ShouldBeBalancedTree()
        {
            //Arrange
            var input = new List<int>(8)
            {
                8, 6, 5, 4, 3, 2, 1
            };

            //Act
            var res = BalancedBST.GenerateBBSTArray(input.ToArray());
            
            //Assert
            AssertArray(res, new List<int> { 4, 2, 6, 1, 3, 5, 8 });
        }
        
        [Fact]
        public void GenerateBBSTArray_1Elements_ShouldBeBalancedTree()
        {
            //Arrange
            var input = new List<int>(8)
            {
                1
            };

            //Act
            var res = BalancedBST.GenerateBBSTArray(input.ToArray());
            
            //Assert
            AssertArray(res, new List<int> { 1 });

        }
        
        [Fact]
        public void GenerateBBSTArray_2Elements_ShouldBeBalancedTree()
        {
            //Arrange
            var input = new List<int>(8)
            {
                2, 1
            };

            //Act
            var res = BalancedBST.GenerateBBSTArray(input.ToArray());
            
            //Assert
            AssertArray(res, new List<int> { 2, 1 });
        }
        
        [Fact]
        public void GenerateBBSTArray_3Elements_ShouldBeBalancedTree()
        {
            //Arrange
            var input = new List<int>(8)
            {
                2, 1, 3
            };

            //Act
            var res = BalancedBST.GenerateBBSTArray(input.ToArray());
            
            //Assert
            AssertArray(res, new List<int> { 2, 1, 3 });
        }
        
        [Fact]
        public void GenerateBBSTArray_Depth15_ShouldBeEqualCount()
        {
            //Arrange
            var input = new List<int>();
            for (int i = 0; i < BalancedBST.GetTreeSize(15); i++)
            {
                input.Add(i);
            }

            //Act
            var res = BalancedBST.GenerateBBSTArray(input.ToArray());
            
            //Assert
            Assert.Equal(res.Length, input.Count);
        }

        void AssertArray(int[] arr, List<int> res)
        {
            for (int idx = 0; idx < arr.Length; idx++)
            {
                Assert.Equal(arr[idx], res[idx]);
            }
        }
    }
}