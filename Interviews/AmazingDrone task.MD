# Amazing drone (a drone in a maze)
You are programming a drone to fly a maze that has high walls and a single target that the drone needs to locate. 
Write an algorithm to determine the minimum distance required for the drone to fly to the target.

**Assumptions:**  
The maze can be represented as a two-dimensional grid of integers. The clear path areas are represented as 0, walls represented by 9 and the target is represented by 1.  
The drone must start from the top-left corner of the grid, which is always clear path, and can move one cell north, south, west, or east at a time. The drone cannot fly into walls and cannot leave the grid.  
  
**Input**  
The input to the function/method consists of one argument:  
<em>grid,</em> representing the two-dimensional grid of integers.

**Output**  
Return an integer representing the minimum distance flown to the target else return -1.

**Constraints**  
1 ≤<em> rows , columns </em>≤ 10<sup>3</sup>

**Example input:**

    grid = [[0, 0, 0],  
            [9, 9, 1],  
            [0, 0, 0]]

**Output:**  
3

**Explanation:**  
Starting from the top-left corner, the drone flew the cells  
(0,0) -&gt; (0,1) -&gt; (0,2) -&gt; (1,2)  
The drone moved the total distance 3 to locate the target.

