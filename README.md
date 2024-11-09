# Maths Game
A simple maths game. A player can choose game to play based on an operation.

## Installation Instructions
- **Clone this repository**
```
git clone https://github.com/omondii/mathsGame.git
```
- **Navigate to the cloned repository**
```
cd mathsGame
```
- **Compile the game source code, this create an executable.dll file in the build directory**
```
dotnet build -o ./build src/MathGame.csproj
```
- **Run your project**
```
cd mathGame/build
```
```
dotnet ./MathGame.dll
```

## Available Operations
1. Addition
2. Subtraction
3. Multiplication
4. Division

## Game Instructions
1. Input player name.
2. Choose an operation from the list of operations.

## Game Rules
- **The rules of the game are:**
1. For each question, you get 3 attempts to answer correctly.
2. For each correct answer, you get 1 point.
3. If you fail all 3 attempts, you get a -1 to your total score.
4. Each operation is a game round and you will be given 5 questions.
5. Your total score is displayed after the final question(5).