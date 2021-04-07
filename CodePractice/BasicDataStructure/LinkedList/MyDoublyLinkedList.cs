using System;
using System.Collections.Generic;

namespace CodePractice.BasicDataStructure.LinkedList
{
    /// <summary>
    /// 实现一个双向链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyDoublyLinkedList<T>
    {
        public MyDoublyLinkedList(Node<T> head)
        {
            Head = head;
            Tail = head;
        }

        public MyDoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        #region Properties

        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        #endregion

        #region Methods

        //获取链表长度
        public int Length()
        {
            if (Head == null)
            {
                return 0;
            }
            int length = 1;
            var node = Head.NextNode;
            //如果为循环链表，则尾结点的NextNode不为空
            while (node != null && node != Head)
            {
                length++;
                node = node.NextNode;
            }
            return length;
        }

        /// <summary>
        /// 是否为空链表
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Head == null;
        }

        /// <summary>
        /// 清空链表
        /// </summary>
        public void Clear()
        {
            //todo 是否需要清空内存中所有的节点？
            var node = Head;
            while (node != null)
            {
                var temp = node.NextNode;
                node = null;
                node = temp;
            }
            Head = null;
        }
        
        /// <summary>
        /// 链表尾部添加一个新节点
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node<T> node)
        {
            if (Tail == null)
            {
                Tail = node;
                return;
            }
            Tail.NextNode = node;
            node.PrevNode = Tail;
            node.NextNode = null;
            Tail = node;
        }

        /// <summary>
        /// 链表插入一个新节点（暂时只实现在target后插入新节点）
        /// </summary>
        /// <param name="target">插入的节点位置</param>
        /// <param name="node">要插入的新节点</param>
        public void Insert(Node<T> target,Node<T> node)
        {
            if (target == null || node == null)
            {
                return;
            }
            node.NextNode = target.NextNode;
            target.NextNode = node;
            node.PrevNode = target;
        }

        /// <summary>
        /// 链表删除一个节点
        /// </summary>
        /// <param name="node">要删除的节点</param>
        public void Delete(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            node.PrevNode.NextNode = node.NextNode;
            node.NextNode.PrevNode = node.PrevNode;
            node = null;
        }

        #endregion

    }
}