module GearRatios.Types

type Position =
    { Coordinates: int * int
      Character: char }

type Schematic = Position seq
