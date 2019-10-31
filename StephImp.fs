namespace Robots

module StephImp =

    open Domain

    // Real implementation (StepF#)
    let rotateLeft =
        function
        | West -> South
        | South -> East
        | East -> North
        | North -> West

    let rotateRight =
        rotateLeft
        >> rotateLeft
        >> rotateLeft

    let advance ({ coordinates = crd; facing = f } as state) =
        match f with
        | North -> { state with coordinates = { crd with y = crd.y + 1 } }
        | East -> { state with coordinates = { crd with x = crd.x + 1 } }
        | South -> { state with coordinates = { crd with y = crd.y - 1 } }
        | West -> { state with coordinates = { crd with x = crd.x - 1 } }

    let runCommand state =
        function
        | Left -> { state with facing = rotateLeft state.facing }
        | Right -> { state with facing = rotateRight state.facing }
        | Forward -> advance state

    let runCommands = List.fold runCommand

    let isValidJourney { initial = initial; commands = commands; final = final } =
        runCommands initial commands |> (=) final
