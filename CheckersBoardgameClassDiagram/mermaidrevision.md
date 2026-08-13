```mermaid
classDiagram
  direction TB

  %% Enumerations
  class PieceColor {
    <<enumeration>>
    RED
    BLACK
  }

  class GameStatus {
    <<enumeration>>
    NOT_STARTED
    IN_PROGRESS
    RED_WINS
    BLACK_WINS
    DRAW
  }

  %% Position Value Object
  class Position {
    <<struct>>
    +int row
    +int column
  }

  %% Single Piece class (no interface - only one piece type exists)
  class Piece {
    +bool isKing : readonly
    +PieceColor Color : readonly
    +PromoteKing() void
  }

  %% Board and Square
  class Square {
    +Piece? piece
    +IsEmpty() bool
    +PlacePiece(Piece piece) void
  }

  class Board {
    +Square[8,8] square
    +GetSquare(Position position) : Square
    +GetPiece(PieceColor color) : int
  }

  %% Move as pure data/intent - no Execute()
  class Move {
    -from: Position
    -to: Position
    -capturedPieces: List~Piece~
    -path: List~Position~
    +From: Position
    +To: Position
    +CapturedPieces: List~Piece~
    +Path: List~Position~
    +IsCapture() bool
    +IsChainCapture() bool
  }

  %% Rules extracted so Board isn't hardcoded to one variant
  class RuleSet {
    <<interface>>
    +bool ForcedCapture
    +bool FlyingKings
    +GetLegalMoves(piece: Piece, board: Board) List~Move~
  }

  class StandardRuleSet {
    +bool ForcedCapture
    +bool FlyingKings
    +GetLegalMoves(piece: Piece, board: Board) List~Move~
  }

  %% Player
  class Player {
    -List~Piece~ pieces
    +PieceColor Color
    +string Name
    +GetPieces() List~Piece~
  }

  %% Game
  class Game {
    -List~Player~ player
    -Player currentPlayer
    -RuleSet rules
    +Board board 
    +GameStatus status
    +CurrentPlayer: Player
    +Status: GameStatus
    +MoveMade: Event Action~Move~
    +GameOver: Event Action~Player~
    +GetRuleSet() RuleSet
    +StartGame(RuleSet, Player one, Player two) void
    +MakeMove(Position from, Position to) void
    +SwitchTurn() Player
    +CheckGameOver() bool
    +GetValidMove(Piece piece) List~Move~
    +Restart() void
  }

  %% Relationships

  %% Interface Implementation
  StandardRuleSet ..|> RuleSet

  %% Composition: Game owns Board
  Game *-- Board : composes

  %% Composition: Board owns 64 Squares
  Board *-- Square : composes 64

  %% Association: Square is the single source of truth for piece location
  Square o-- Piece : contains 0..1

  %% Composition: Game owns Players
  Game *-- Player : composes 2

  %% Association: Player has multiple pieces
  Player --> Piece : manages 0..*

  %% Association: Move references positions
  Move --> Position : from 1
  Move --> Position : to 1
  Move --> Position : path 0..*

  %% Association: Move may capture pieces (chain capture support)
  Move --> Piece : captures 0..*

  %% Dependency: Game uses Move; Board is the sole mutator
  Game --> Move : creates
  Game --> Board : delegates MakeMove

  %% Rules are pluggable and used by both Board and Player
  Game *-- RuleSet : composes

  %% Value Object: Position used throughout
  Square --> Position : locates
  Piece --> Position : occupies

  %% Enumerations used
  Piece --> PieceColor : has
  Player --> PieceColor : has
  Game --> GameStatus : tracks
  Game --> PieceColor : uses
```