module Qry.Query 

open FParsec

type BinaryExprKind =
    | Add 
    | Subtract 
    | Multiply 
    | Divide 
    | And 
    | Or 
    | Equals 
    | NotEquals 
    | GreaterThan 
    | GreaterThanorEquals 
    | LesserThan 
    | LesserThanorEquals
type Expr = 
    | IntLiteral of int
    | FloatLiteral of float
    | StringLiteral of string
    |Identifier of identifier
    |Binary of (Expr * Expr * Expr * BinaryExprKind)

type Stmt = 
    | FilterBy of Expr
    | OrderBy of Expr * OrderBy
    | Skip of int 
    | Take of int

type Query = {
    Statements : Stmt list
}

// 'hello world' 

let quote : Parser<_, unit> = skipChar '\' '

let stringLiteral = quote >>. manyCharsTill anyChar quote