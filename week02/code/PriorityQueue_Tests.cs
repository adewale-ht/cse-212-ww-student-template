using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities (10, 5, 15) and dequeue them.
    // Expected Result: Items should be dequeued in order of highest priority first: 15, 10, 5
    // Defect(s) Found: PriorityQueue.Dequeue had loop boundary error (< Count - 1 instead of < Count) missing last element; also missing _queue.RemoveAt(highPriorityIndex) call.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item A", 10);
        priorityQueue.Enqueue("Item B", 5);
        priorityQueue.Enqueue("Item C", 15);

        // Dequeue in priority order
        Assert.AreEqual("Item C", priorityQueue.Dequeue()); // Priority 15 (highest)
        Assert.AreEqual("Item A", priorityQueue.Dequeue()); // Priority 10
        Assert.AreEqual("Item B", priorityQueue.Dequeue()); // Priority 5 (lowest)
    }

    [TestMethod]
    // Scenario: Add items and verify that when multiple items have the same priority, the first one (by insertion order) is returned.
    // Expected Result: With equal priorities, the queue should handle it gracefully and return items consistently.
    // Defect(s) Found: Fixed by loop boundary and RemoveAt corrections.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        // With equal priorities, >= operator means we get the last one added with that priority
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("First", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items, dequeue some, add more, then dequeue all remaining.
    // Expected Result: Items are always dequeued in order of highest priority regardless of insertion time.
    // Defect(s) Found: None after fixes.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 8);
        
        Assert.AreEqual("B", priorityQueue.Dequeue()); // Priority 8 (highest)
        
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 10);
        
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Priority 10 (now highest)
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Priority 5
        Assert.AreEqual("A", priorityQueue.Dequeue()); // Priority 3
    }
}
