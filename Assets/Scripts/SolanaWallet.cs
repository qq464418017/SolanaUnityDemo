using System;
using System.Collections;
using System.Collections.Generic;
using Solana.Unity.Rpc.Core.Http;
using Solana.Unity.Rpc.Messages;
using Solana.Unity.Rpc.Models;
using Solana.Unity.SDK;
using Solana.Unity.Wallet;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SolanaWallet : MonoBehaviour
{
    public Button LoginBtn;
    public TMP_Text text;

    private void Awake()
    {
        LoginBtn.onClick.AddListener(OnClickLogin);
    }

    private async void OnClickLogin()
    {
        
        await Web3.Instance.LoginWalletAdapter();
        TestGetBalance();
    }
    
    private async void TestGetBalance()
    {
        // await UniTask.Delay(5000);
        Log("------------------------------");
        Log("Wallet: " + Web3.Account.PublicKey);
        string key = "4zMMC9srt5Ri5X14GAgXhaHii3GnPAEERYPJgZJDncDU";
        RequestResult<ResponseValue<TokenBalance>> value = await Web3.Rpc.GetTokenBalanceByOwnerAsync(Web3.Account.PublicKey, key);
        Log("WasSuccessful: " + value.WasSuccessful);
        Log("WasHttpRequestSuccessful: " + value.WasHttpRequestSuccessful);
        Log("WasRequestSuccessfullyHandled: " + value.WasRequestSuccessfullyHandled);
        Log("Reason: " + value.Reason);
        Log("HttpStatusCode: " + value.HttpStatusCode);
        Log("RawRpcRequest: " + value.RawRpcRequest);
        Log("RawRpcResponse: " + value.RawRpcResponse);
        
        Log("Amount: " + value.Result.Value.Amount);
        Log("Decimals: " + value.Result.Value.Decimals);
        Log("AmountDecimal: " + value.Result.Value.AmountDecimal);
        Log("AmountDouble: " + value.Result.Value.AmountDouble);
        Log("AmountUlong: " + value.Result.Value.AmountUlong);
        Log("UiAmountString: " +  value.Result.Value.UiAmountString);
        
        Log("++++++++++++++++++++++++");
    }

    private void Log(string value)
    {
        text.text += value + "\r\n";
    }
}
