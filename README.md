# AcrLoginTest

Minimal repro for [microsoft/aspire#13904](https://github.com/microsoft/aspire/issues/13904) — Azure CLI timeout during ACR login in `aspire deploy` on GitHub Actions.

## Problem

When running `aspire deploy` in a GitHub Actions workflow, the `login-to-acr` step
frequently fails with:

```
Login to ACR xxx.azurecr.io failed: Azure CLI authentication timed out.
```

The root cause is that Aspire uses `AzureCliCredential` for the ACR login step,
which shells out to `az account get-access-token`. That subprocess has a ~13s timeout
in `Azure.Identity`, and on hosted CI agents it frequently exceeds that.

## Setup

1. Create an Azure resource group and configure OIDC federation for GitHub Actions.
2. Set the following GitHub repository variables:
   - `AZURE_CLIENT_ID`
   - `AZURE_TENANT_ID`
   - `AZURE_SUBSCRIPTION_ID`
   - `AZURE_LOCATION` (e.g. `southafricanorth` or `westus3`)
   - `AZURE_ENV_NAME` (environment name for Aspire)
3. Push to `main` or trigger the workflow manually.

## Expected

`aspire deploy` completes successfully, including the ACR login step.

## Actual

The `login-to-acr-*` step times out ~80% of the time with:

```
Azure CLI authentication timed out.
```
