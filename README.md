# About
Pathfinding problem solve with the following methods:<br>
## Greedy Hill Climbing
 In numerical analysis, hill climbing is a mathematical optimization technique which belongs to the family of local search. It is an iterative algorithm that starts with an arbitrary solution to a problem, then attempts to find a better solution by making an incremental change to the solution. If the change produces a better solution, another incremental change is made to the new solution, and so on until no further improvements can be found. The new solution point is selected based on heuristic info.
 
## Hill Climbing with Simulated Annealing
Simulated annealing (SA) is a probabilistic technique for approximating the global optimum of a given function. Specifically, it is a metaheuristic to approximate global optimization in a large search space for an optimization problem. It is often used when the search space is discrete (e.g., the traveling salesman problem). For problems where finding an approximate global optimum is more important than finding a precise local optimum in a fixed amount of time, simulated annealing may be preferable to alternatives such as gradient descent. 

## A* Search Algorithm
A* is a graph traversal and path search algorithm, which is often used in computer science due to its completeness, optimality, and optimal efficiency.
# Input Format
<p align="center">
  <img src="/Images/input_format.png"  width="500">
</p>

# Example
<p align="center">
  <img src="/Images/romania_map_example.png">
</p>

## Heuristics
- Arad, 366
- Bucharest, 0
- Craiova, 160
- Dobreta, 242
- Eforie, 161
- Fagaras, 176
- Giurgiu, 77
- Hirsowa, 151
- Lasi, 226
- Lugoj, 244
- Mehadia, 241
- Neamt, 234
- Oradea, 380
- Pitesti, 100
- Rimnicu Vilcea, 193
- Sibiu, 253
- Timisoara, 329
- Urziceni, 80
- Vaslui, 199
- Zerind, 374

### Greedy Hill Climbing worked fast but stuck at local optimum.

### Time: 0.0005223 sec

### Total Distance: 450

<p align="center">
  <img src="/Images/romania_map_localoptimum.gif">
</p>

### Simulated Annealing and A* Search found global optimum.

### SA Time: 0.4283346 sec

### A* Time: 0.0038134 sec

### Total Distance: 418

<p align="center">
  <img src="/Images/romania_map_globaloptimum.gif">
</p>
