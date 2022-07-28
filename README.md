# Words Frequency. MapReduce Approch

Intermediate level task for practicing collection classes.

Estimated time to complete the task - 2h.

The task requires .NET 6 SDK installed.

## Task Details

Calculate the frequency of each word in an input text. In practice, source text can be read from a set of text files. The basic steps of a job are:
- input
- splitting
- mapping
- shuffling
- reducing
- output
First the input is split to distribute the work among all the map nodes as shown in the figure. Then each word is identified and mapped to the number one. Thus the pairs also called as tuples are created. In the first mapper node four words 'He', 'who', 'free' and 'is' are passed. Thus the output of the node will be four key/value pairs with four distinct keys and value set to one. The mapping process remains the same in all the nodes. These tuples are then passed to the reduce nodes.  A partitioner comes into action which carries out shuffling so that all the tuples with same key are sent to same node.The Reducer node processes all the tuples such that all the pairs with same key are counted and the count is updated as the value of that specific key. In the example there are two pairs with the key 'brave' which are then reduced to single tuple with the value equal to the count. In th future all the output tuples then may be collected and written for example in the output file.

![](Images/map-reduce-words-frequency.png)
