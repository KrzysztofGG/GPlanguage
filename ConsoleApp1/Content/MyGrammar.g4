grammar MyGrammar;

WS: [ \t\r\n]+ -> skip;

LPAREN: '(';
RPAREN: ')';
LBRACE: '{';
RBRACE: '}';

ADD: '+';
SUB: '-';
MUL: '*';
DIV: '/';
MOD: '%';

ASS: '=';

EQ: '==';
NEQ: '!=';
LE: '<';
LEQ: '<=';
GE: '>';
GEQ: '>=';

AND: '&&';
OR: '||';
NOT: '!';

TRUE: 'true';
FALSE: 'false';

IF: 'if';
WHILE: 'while';

PRINT: 'print';
SCAN: 'scan';

NUMBER: [0-9]+ ('.' [0-9]+)?;
NUM_VAR: 'X' [0-9];
BOOL_VAR: 'L' [0-9];

program: expressions;

//! ----- EXPRESSIONS -----
expressions
    :   ( if_statement
        | while_loop
        | print_call
        | scan_call
        | assignment) expressions?
    ;

//! ----- IF_STATEMENT -----
if_statement: IF LPAREN bool_value RPAREN LBRACE expressions RBRACE #ifStatement;

//! ----- WHILE_LOOP -----
while_loop  : WHILE LPAREN bool_value RPAREN LBRACE expressions RBRACE #whileStatement;

//! ----- PRINT_CALL -----
print_call
    : PRINT LPAREN numeric_value RPAREN #printNum
    | PRINT LPAREN  bool_value   RPAREN #printBool
    ;

//! ----- SCAN_CALL -----
scan_call
    : SCAN LPAREN NUM_VAR  RPAREN #scanNum
    | SCAN LPAREN BOOL_VAR RPAREN #scanBool
    ;

//! ----- ASSIGNMENT -----
assignment
    : NUM_VAR  ASS numeric_value #AssignNum
    | BOOL_VAR ASS bool_value #AssignBool
    ;

//! ----- MATH & LOGIC -----
comparisson_type            : EQ  | NEQ | LE  | LEQ | GE  | GEQ;
logic_operator              : AND | OR  ;
aritmetic_operator_strong   : MUL | DIV | MOD ;
aritmetic_operator_weak     : ADD | SUB ;

bool_value
    : BOOL_VAR #boolVarVal
    | TRUE #trueVal
    | FALSE #falseVal
    | NOT bool_value #notVal
    | numeric_value comparisson_type numeric_value #compVal
    | bool_value     logic_operator     bool_value #logicVal
    | LPAREN bool_value RPAREN #parenBoolVal
    ;

numeric_value
    : NUMBER #numVal
    | NUM_VAR #numVarVal
    | SUB numeric_value #subVal
    | numeric_value aritmetic_operator_strong numeric_value #aritStrongVal
    | numeric_value  aritmetic_operator_weak  numeric_value #aritWeakVal
    | LPAREN numeric_value RPAREN #parenNumVal
    ;