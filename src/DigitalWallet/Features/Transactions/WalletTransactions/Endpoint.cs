﻿using Carter;

namespace DigitalWallet.Features.Transactions.WalletTransactions;

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapGroup(FeatureManager.Prefix)
            .WithTags(FeatureManager.EndpointTagName)
            .MapGet("/{wallet_id:guid:required}",
            async ([FromRoute(Name = "wallet_id")] Guid Id, [AsParameters] WalletTransactionsRequest requst, WalletDbContext _dbContext, CancellationToken cancellationToken) =>
            {
                var walletId = WalletId.Create(Id);

                var transactions = await _dbContext.Transactions
                    .Where(x => x.WalletId == walletId.Value)
                    .Where(x => x.CreatedOnUtc >= requst.FromDate && x.CreatedOnUtc <= requst.ToDate)
                    .OrderByDescending(x => x.CreatedOnUtc)
                    .Select(x => new
                    {
                        CreatedOnUtc = x.CreatedOnUtc,
                        Descripiton = x.Description,
                        Type = x.Type,
                        TypeName = x.Type.ToString(),
                        Kind = x.Kind,
                        KindName = x.Kind.ToString()
                    })
                    .ToListAsync(cancellationToken);

                return Results.Ok(transactions);
            });
    }
}