using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace ProjectEuler.Primes
{
    /// <summary>
    /// This class represents a prime sieve, consisting of up to 1,000,000 entries per sieve array. 
    /// Each array is stored as a separate file and can be indexed. The sieve has an index file
    /// listing all entries.
    /// </summary>
    public class PrimeSieve
    {
        private const Int64 SEGMENT_LENGTH = 1000000;

        // Current loaded segment of sieve
        private ArrayList _segments;

        // Index of the loaded segment
        private Int64 _segmentIndex;

        public PrimeSieve()
        {
            // Current segment index is -1 by default
            _segmentIndex = -1;
            
            // Loaded segment is null
            _segments = new ArrayList();
        }

        /// <summary>
        /// Determine whether or not a number is prime
        /// </summary>
        /// <param name="value">The value to check primality</param>
        /// <returns>True if the value is prime, false otherwise</returns>
        public bool IsPrime(Int64 value)
        {
            // First, determine which segment the desired value would be stored
            Int64 index = GetSegmentIndex(value);

            // Now that we have the segment index, determine whether the sieve has populated data
            // sufficiently large for this segment.
            if (index >= _segments.Count)
            {
                BuildSieveToIndex(index);
            }

            // Retrieve the value
            Int64 prime = GetValueFromSieve(index, value);

            return prime == 1; 
        }

        /// <summary>
        /// Return the segment index of this value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private Int64 GetSegmentIndex(Int64 value)
        {
            Int64 index = 0;

            // Offset value by 2
            value -= 2;

            while (value > SEGMENT_LENGTH)
            {
                value -= SEGMENT_LENGTH;
                ++index;
            }

            return index;
        }

        // Load a segment of the sieve based on its index
        private void BuildSieveToIndex(Int64 index)
        {
            // Get current index value
            Int64 currentIndices = _segments.Count;

            // Initialize the new segment
            Int64[] segment = new Int64[SEGMENT_LENGTH];

            // Add the segment
            _segments.Add(segment);

            SieveState.ThreadsRemaining = SEGMENT_LENGTH;
            ManualResetEvent doneEvent = new ManualResetEvent(false);
            SieveState.DoneEvent = doneEvent;
            ThreadPool.SetMaxThreads(100, 100);

            // Populate each segment
            for (Int64 i = 0; i < SEGMENT_LENGTH; ++i)
            {
                // Find the true value for this segment index
                Int64 value = i + (index * SEGMENT_LENGTH) + 2;

                SieveState sieveState = new SieveState(value, segment, i);
                ThreadPool.QueueUserWorkItem(new WaitCallback(sieveState.Calculate), i); 
            }

            // Wait for events
            doneEvent.WaitOne();
        }

        private Int64 GetValueFromSieve(Int64 index, Int64 value)
        {
            // Get sub-index [ value - (index * SEGMENT_LENGTH) - 2 ]
            Int64 subIndex = value - (index * SEGMENT_LENGTH) - 2;
            Int64[] segment = (Int64[])(_segments[Convert.ToInt32(index)]);
            return segment[subIndex];
        }
    }

    public class SieveState
    {
        private Int64 _value;

        private Int64[] _segment;

        private Int64 _subIndex;

        public static ManualResetEvent DoneEvent;

        public static Int64 ThreadsRemaining;

        public SieveState(Int64 inValue, Int64[] inSegment, Int64 inSubIndex)
        {
            _value = inValue;
            _segment = inSegment;
            _subIndex = inSubIndex;
        }

        public void Calculate(Object state)
        {
            // Iterate through all values and determine whether this index is composite or prime
            bool isPrime = true;
            for (Int64 j = 2; j < _value; ++j)
            {
                if (_value % j == 0)
                {
                    // Mark as composite
                    _segment[_subIndex] = 0;
                    isPrime = false;
                    break;
                }
            }

            if (isPrime == true)
            {
                _segment[_subIndex] = 1;
            }

            // Fire done event
            if (Interlocked.Decrement(ref ThreadsRemaining) == 0)
            {
                DoneEvent.Set();
            }
        }
    }
}
