CREATE TYPE OperationTypes AS ENUM(
    'ADD',
    'TAKE'
);

CREATE TABLE Accounts (
    AccountId BIGINT PRIMARY KEY,
    AccountPassword BIGINT,
    AccountBalance DECIMAL
);

CREATE TABLE OperationHistory (
    OperationId BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    AccountId BIGINT REFERENCES Accounts(AccountId),
    OperationType OperationTypes,
    Amount DECIMAL 
);

INSERT INTO Accounts(AccountId, AccountPassword, AccountBalance)
VALUES (1, 1111, 1234), 
       (2, 2222, 5678),
       (3, 3333, 0)