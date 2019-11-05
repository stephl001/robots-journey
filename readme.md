# Robots Journey

This is a simple exercise about parsing and simple coordinates transformation.

### The Challenge

You are given a file, something like this:

```
1 1 E
RFRFRFRF
1 1 E

3 2 N
FRRFLLFFRRFLL
3 3 N

0 3 W
LLFFFLFLFL
2 4 S
```

It contains zero to many (in this case 3) journeys.
Here's the first one:

```
1 1 E
RFRFRFRF
1 1 E
```

Each one starts with the initial coordinates of the robot (1 1 in this case) and the direction it is pointing in. In this case E = East.
The directions are as follows:

```
N = North
E = East
S = South
W = West
```

Following the starting conditions are a list of commands:

```
RFRFRFRF
```

Each character is a command, either to turn (L = left, R = right) or to move forwards (F).

Finally the journey ends with another set of coordinates and a direction. This is the expected position and orientation of your robot at the end of the journey. Your program should check that it ends at the specified coordinates and facing in the given direction.

The challenge is to parse the input file, set the start position of your robot, then have it execute the instructions and check its final postion with the expected position.

### Implementation

Before we look at the parsing, lets simply implement the command execution algorithm. To do so, simply implement the `runCommands` function in the Robots.fs file. To make sure your implementation is right, make sure to run all unit tests. To execute the unit tests, from a console, execute the following command:

```
dotnet test
```

Right now, only the first test is set to run. Using a TDD approach, you can unskip the following tests one by one as soon as all the currently enabled tests pass. To unskip a test, simply remove the `Skip="..."` within the `Property` attribute for each test. You may ignore the current test implementation with all the weird generator and arbitrary constructs. This is an FsCheck feature and all tests are property based tests.

### Parsing

Instructions will be provided soon.
