﻿using AlgorithmsDataStructures;
using Xunit;

namespace LinkedList_1.Tests
{
    public partial class LinkedListTests
    {
        [Fact]
        public void Remove_ListEmpty_ShouldReturnFalse()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var isRemoved = list.Remove(15);
            
            //Assert
            Assert.False(isRemoved);
        }
        
        [Fact]
        public void Remove_ListHasOneElement_ShouldReturnTrueAndCorrectTailHeadCount()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var node1 = new Node(15);
            list.AddInTail(node1);
            var isRemoved = list.Remove(15);
            
            //Assert
            Assert.True(isRemoved);
            Assert.Equal(0, list.count);

            var head = list.head;
            var tail = list.tail;
            
            Assert.Null(head);
            Assert.Null(tail);
        }
        
        [Fact]
        public void Remove_ListHasTwoElementRemoveAtHead_ShouldReturnTrueAndCorrectTailHeadCount()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var node1 = new Node(15);
            var node2 = new Node(16);
            list.AddInTail(node1);
            list.AddInTail(node2);
            var isRemoved = list.Remove(15);
            
            //Assert
            Assert.True(isRemoved);
            Assert.Equal(1, list.count);

            var head = list.head;
            var tail = list.tail;
            
            Assert.NotNull(head);
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(16, head.value);
            Assert.Equal(16, tail.value);
        }
        
        [Fact]
        public void Remove_ListHasTwoElementRemoveAtTail_ShouldReturnTrueAndCorrectTailHeadCount()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var node1 = new Node(15);
            var node2 = new Node(16);
            list.AddInTail(node1);
            list.AddInTail(node2);
            var isRemoved = list.Remove(16);
            
            //Assert
            Assert.True(isRemoved);
            Assert.Equal(1, list.count);

            var head = list.head;
            var tail = list.tail;
            
            Assert.NotNull(head);
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(15, head.value);
            Assert.Equal(15, tail.value);
        }
        
        [Fact]
        public void Remove_ListNotEmptyRemovedAtStart_ShouldReturnTrueAndCorrectTailHeadCount()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var node1 = new Node(15);
            var node2 = new Node(16);
            var node3 = new Node(17);
            var node4 = new Node(18);
            var node5 = new Node(19);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            list.AddInTail(node5);
            var isRemoved = list.Remove(15);
            
            //Assert
            Assert.True(isRemoved);
            Assert.Equal(4, list.count);

            var head = list.head;
            var tail = list.tail;
            
            Assert.NotNull(head);
            Assert.Equal(16, head.value);
            Assert.NotNull(head.next);
            
            Assert.NotNull(tail);
            Assert.Equal(19, tail.value);
            Assert.Null(tail.next);


            var next = head.next;
            Assert.NotNull(next);
            Assert.Equal(17, next.value);
            
            next = next.next;
            Assert.NotNull(next);
            Assert.Equal(18, next.value);
            
            next = next.next;
            Assert.NotNull(next);
            Assert.Equal(19, next.value);
            
            var found = list.Find(node1.value);
            Assert.Null(found);
            
            found = list.Find(node2.value);
            Assert.NotNull(found);
            
            found = list.Find(node3.value);
            Assert.NotNull(found);
            
            found = list.Find(node4.value);
            Assert.NotNull(found);
            found = list.Find(node5.value);
            Assert.NotNull(found);
        }
        
        [Fact]
        public void Remove_ListNotEmptyRemovedAtMiddle_ShouldReturnTrueAndCorrectTailHeadCount()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var node1 = new Node(15);
            var node2 = new Node(16);
            var node3 = new Node(17);
            var node4 = new Node(18);
            var node5 = new Node(19);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            list.AddInTail(node5);
            var isRemoved = list.Remove(17);
            
            //Assert
            Assert.True(isRemoved);
            Assert.Equal(4, list.count);

            var head = list.head;
            var tail = list.tail;
            
            Assert.NotNull(head);
            Assert.Equal(15, head.value);
            Assert.NotNull(head.next);
            
            Assert.NotNull(tail);
            Assert.Equal(19, tail.value);
            Assert.Null(tail.next);


            var next = head.next;
            Assert.NotNull(next);
            Assert.Equal(16, next.value);
            
            next = next.next;
            Assert.NotNull(next);
            Assert.Equal(18, next.value);
            
            next = next.next;
            Assert.NotNull(next);
            Assert.Equal(19, next.value);
            
            var found = list.Find(node1.value);
            Assert.NotNull(found);
            
            found = list.Find(node2.value);
            Assert.NotNull(found);
            
            found = list.Find(node3.value);
            Assert.Null(found);
            
            found = list.Find(node4.value);
            Assert.NotNull(found);
            
            found = list.Find(node5.value);
            Assert.NotNull(found);
        }
        
        [Fact]
        public void Remove_ListNotEmptyRemovedAtEnd_ShouldReturnTrueAndCorrectTailHeadCount()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var node1 = new Node(15);
            var node2 = new Node(16);
            var node3 = new Node(17);
            var node4 = new Node(18);
            var node5 = new Node(19);
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            list.AddInTail(node5);
            var isRemoved = list.Remove(19);
            
            //Assert
            Assert.True(isRemoved);
            Assert.Equal(4, list.count);

            var head = list.head;
            var tail = list.tail;
            
            Assert.NotNull(head);
            Assert.Equal(15, head.value);
            Assert.NotNull(head.next);
            
            Assert.NotNull(tail);
            Assert.Equal(18, tail.value);
            Assert.Null(tail.next);
            
            var next = head.next;
            Assert.NotNull(next);
            Assert.Equal(16, next.value);
            
            next = next.next;
            Assert.NotNull(next);
            Assert.Equal(17, next.value);
            
            next = next.next;
            Assert.NotNull(next);
            Assert.Equal(18, next.value);
            
            var found = list.Find(node1.value);
            Assert.NotNull(found);
            
            found = list.Find(node2.value);
            Assert.NotNull(found);
            
            found = list.Find(node3.value);
            Assert.NotNull(found);
            
            found = list.Find(node4.value);
            Assert.NotNull(found);
            
            found = list.Find(node5.value);
            Assert.Null(found);
        }
        
        [Fact]
        public void Remove_ListNotEmptyRemovedAll_ShouldReturnTrueAndCorrectTailHeadCount()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var node1 = new Node(15);
            var node2 = new Node(16);
            var node3 = new Node(17);
            var node4 = new Node(18);
            var node5 = new Node(19);
            
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            list.AddInTail(node5);
            
            var isRemoved = list.Remove(19);
            isRemoved = list.Remove(15);
            isRemoved = list.Remove(16);
            isRemoved = list.Remove(17);
            isRemoved = list.Remove(18);
            
            //Assert
            Assert.True(isRemoved);
            Assert.Equal(0, list.count);

            var head = list.head;
            var tail = list.tail;
            
            Assert.Null(head);
            Assert.Null(tail);
        }
        
        [Fact]
        public void Remove_ListNotEmptyRemovedAllExceptOne_ShouldReturnTrueAndCorrectTailHeadCount()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var node1 = new Node(15);
            var node2 = new Node(16);
            var node3 = new Node(17);
            var node4 = new Node(18);
            var node5 = new Node(19);
            
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            list.AddInTail(node5);
            
            var isRemoved = list.Remove(19);
            isRemoved = list.Remove(15);
            isRemoved = list.Remove(17);
            isRemoved = list.Remove(18);
            
            //Assert
            Assert.True(isRemoved);
            Assert.Equal(1, list.count);

            var head = list.head;
            var tail = list.tail;
            
            Assert.NotNull(head);
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Null(head.next);
            
            Assert.Equal(16, head.value);
            Assert.Equal(16, tail.value);
        }
        
        [Fact]
        public void Remove_ListNotEmptyRemovedAllExceptTwo_ShouldReturnTrueAndCorrectTailHeadCount()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var node1 = new Node(15);
            var node2 = new Node(16);
            var node3 = new Node(17);
            var node4 = new Node(18);
            var node5 = new Node(19);
            
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            list.AddInTail(node5);
            
            var isRemoved = list.Remove(19);
            isRemoved = list.Remove(16);
            isRemoved = list.Remove(17);

            //Assert
            Assert.True(isRemoved);
            Assert.Equal(2, list.count);

            var head = list.head;
            var tail = list.tail;
            
            Assert.NotNull(head);
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.NotNull(head.next);
            
            Assert.Equal(18, head.next.value);
            Assert.Equal(15, head.value);
            Assert.Equal(18, tail.value);
        }
    }
}