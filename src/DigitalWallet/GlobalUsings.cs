﻿// built-in
global using System.Net;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using System.Diagnostics.CodeAnalysis;
global using Microsoft.AspNetCore.Mvc;

// third-party
global using FluentValidation;

// solution
global using DigitalWallet.Features.MultiCurrency;
global using DigitalWallet.Features.MultiCurrency.Common;
global using DigitalWallet.Features.Transactions;
global using DigitalWallet.Features.UserWallet;
global using DigitalWallet.Common.Filters;
global using DigitalWallet.Database.WalletDbContextModels;
global using DigitalWallet.Features.MultiCurrency.CreateCurrency;
global using DigitalWallet.Features.MultiCurrency.UpdateRatio;
global using DigitalWallet.Features.UserWallet.Common;
global using DigitalWallet.Features.UserWallet.ChangeTitle;
global using DigitalWallet.Features.UserWallet.CreateWallet;
global using DigitalWallet.Features.UserWallet.Suspend;
global using DigitalWallet.Features.UserWallet.GetBalance;
global using DigitalWallet.Features.Transactions.WalletFunds;
global using DigitalWallet.Features.Transactions.WalletTransactions;
global using DigitalWallet.Features.UserWallet.GetTransactions;
global using DigitalWallet.Features.Transactions.Common;
global using DigitalWallet.Features.MultiCurrency.GetAll;
global using DigitalWallet.Features.UserWallet.Active;