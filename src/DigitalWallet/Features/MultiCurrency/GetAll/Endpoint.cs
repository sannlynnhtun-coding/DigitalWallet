﻿using Carter;

namespace DigitalWallet.Features.MultiCurrency.GetAll;

public class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapGroup(FeatureManager.Prefix)
            .WithTags(FeatureManager.EndpointTagName)
            .MapGet("/",
                async (WalletDbContext dbContext, CancellationToken cancellationToken) =>
                {
                    var currencies = await GetCurrencies(dbContext, cancellationToken);

                    return Results.Ok(currencies);
                });
    }

    public static async Task<List<GetCurrencyResponse>> GetCurrencies(WalletDbContext dbContext,
        CancellationToken cancellationToken)
    {
        var currencies = await dbContext.Currencies
            .OrderByDescending(x => x.Name)
            .Select(x => new GetCurrencyResponse
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Code = x.Code,
                Ratio = x.Ratio
            })
            .ToListAsync(cancellationToken);
        return currencies;
    }
}