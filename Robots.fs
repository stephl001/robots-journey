namespace Robots

module Domain =

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
    type IsValidJourneyDef = Journey -> bool
