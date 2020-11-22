CREATE TABLE [dbo].[client] (
    [Email]    VARCHAR (35) NOT NULL,
    [FullName] VARCHAR (25) NOT NULL,
    [Address]  VARCHAR (50) NOT NULL,
    [Age]      INT          NOT NULL,
    [Phone]    VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([email] ASC)
);


CREATE TABLE [dbo].[event] (
    [EventName]   VARCHAR (25) NOT NULL,
    [Description] VARCHAR (60) NOT NULL,
    [Location]    VARCHAR (20) NOT NULL,
    [Date]        VARCHAR (10) NOT NULL,
    [TicketFee]   FLOAT (53)   NOT NULL,
    PRIMARY KEY CLUSTERED ([EventName] ASC)
);


CREATE TABLE [dbo].[register] (
    [ID]            INT          IDENTITY (1, 1) NOT NULL,
    [GuestNumber]   INT          NOT NULL,
    [PaymentAmount] FLOAT (53)   NULL,
    [EventName]     VARCHAR (25) NULL,
    [Email]         VARCHAR (35) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([Email]) REFERENCES [dbo].[client] ([email]),
    FOREIGN KEY ([EventName]) REFERENCES [dbo].[event] ([EventName])
);

