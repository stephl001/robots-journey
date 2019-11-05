module Robots

type Direction =
    | North
    | East
    | South
    | West

type Command =
    | Right
    | Left
    | Forward

type Coordinates =
    { x: int
      y: int }

type RobotInfo =
    { coordinates: Coordinates
      facing: Direction }

type Journey =
    { initial: RobotInfo
      commands: Command list
      final: RobotInfo }

//This is the definition of the function to create in your implementation
let runCommands (state:RobotInfo) (commands:Command list) =
    failwith "Please, implement this function..."
