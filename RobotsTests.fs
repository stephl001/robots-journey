// This file was created manually and its version is 2.0.0.

module RobotsTest

open FsCheck.Xunit
open Robots
open FsCheck

[<Property>]
let ``Empty list of commands should yeild the exact same starting position``(state:RobotInfo) =
    runCommands state [] = state

let turnGenerator =
    Gen.elements [Right; Left]

type OnlyTurnCommands =
    static member Commands() = turnGenerator |> Gen.listOf |> Arb.fromGen

[<Property(Arbitrary = [| typeof<OnlyTurnCommands> |], Skip = "Romove to run test")>]
let ``Running only turn commands should not alter the robot initial position`` (state:RobotInfo) commands =
    let newState = runCommands state commands
    newState.coordinates = state.coordinates

let robotDistance {coordinates={x=x1; y=y1}; facing=_} {coordinates={x=x2; y=y2}; facing=_} =
    (x2-x1)*(x2-x1) + (y2-y1)*(y2-y1) |> (float >> sqrt)

let forwardListGenerator =
    (Gen.constant Forward) |> Gen.listOf

let oneTurnGenerator =
    let concatElems l1 t l2 = List.concat [l1; [t]; l2]
    Gen.map3 concatElems forwardListGenerator turnGenerator forwardListGenerator

type OnlyOneTurnCommands =
    static member Commands() = oneTurnGenerator |> Arb.fromGen

[<Property(Arbitrary = [| typeof<OnlyOneTurnCommands> |], Skip = "Romove to run test")>]
let ``Make sure the final robot has the expected distance with only one turn`` state commands =
    let newState = runCommands state commands
    let distance = robotDistance state newState
    let maxDistance = float <| commands.Length - 1
    let minDistance = sqrt <| (float maxDistance / 2.0 * float maxDistance / 2.0) * 2.0
    distance >= minDistance && distance <= maxDistance

let substractCoordinates {x=x1; y=y1} {x=x2; y=y2} =
    {x=x2-x1; y=y2-y1}

let addCoordinates {x=x1; y=y1} {x=x2; y=y2} =
    {x=x2+x1; y=y2+y1}

[<Property(Skip = "Romove to run test")>]
let ``Adding deltas between normal and opposite commands should yield {0, 0} coordinates`` state commands =
    let newState = runCommands state commands
    let oppositeState = runCommands state (Right::Right::commands)
    let substractFromOriginal = substractCoordinates state.coordinates
    let deltaNewState = substractFromOriginal newState.coordinates
    let deltaOpposite = substractFromOriginal oppositeState.coordinates
    addCoordinates deltaNewState deltaOpposite = {x=0; y=0}
