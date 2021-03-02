using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
        public class RhAccount
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("portfolio_cash")]
            public string PortfolioCash { get; set; }

            [JsonProperty("can_downgrade_to_cash")]
            public string CanDowngradeToCash { get; set; }

            [JsonProperty("user")]
            public string User { get; set; }

            [JsonProperty("account_number")]
            public string AccountNumber { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("deactivated")]
            public bool Deactivated { get; set; }

            [JsonProperty("deposit_halted")]
            public bool DepositHalted { get; set; }

            [JsonProperty("withdrawal_halted")]
            public bool WithdrawalHalted { get; set; }

            [JsonProperty("only_position_closing_trades")]
            public bool OnlyPositionClosingTrades { get; set; }

            [JsonProperty("buying_power")]
            public string BuyingPower { get; set; }

            [JsonProperty("cash_available_for_withdrawal")]
            public string CashAvailableForWithdrawal { get; set; }

            [JsonProperty("cash")]
            public string Cash { get; set; }

            [JsonProperty("amount_eligible_for_deposit_cancellation")]
            public string AmountEligibleForDepositCancellation { get; set; }

            [JsonProperty("cash_held_for_orders")]
            public string CashHeldForOrders { get; set; }

            [JsonProperty("uncleared_deposits")]
            public string UnclearedDeposits { get; set; }

            [JsonProperty("sma")]
            public string Sma { get; set; }

            [JsonProperty("sma_held_for_orders")]
            public string SmaHeldForOrders { get; set; }

            [JsonProperty("unsettled_funds")]
            public string UnsettledFunds { get; set; }

            [JsonProperty("unsettled_debit")]
            public string UnsettledDebit { get; set; }

            [JsonProperty("crypto_buying_power")]
            public string CryptoBuyingPower { get; set; }

            [JsonProperty("max_ach_early_access_amount")]
            public string MaxAchEarlyAccessAmount { get; set; }

            [JsonProperty("cash_balances")]
            public object CashBalances { get; set; }

            [JsonProperty("margin_balances")]
            public MarginBalances MarginBalances { get; set; }

            [JsonProperty("sweep_enabled")]
            public bool SweepEnabled { get; set; }

            [JsonProperty("instant_eligibility")]
            public InstantEligibility InstantEligibility { get; set; }

            [JsonProperty("option_level")]
            public string OptionLevel { get; set; }

            [JsonProperty("is_pinnacle_account")]
            public bool IsPinnacleAccount { get; set; }

            [JsonProperty("rhs_account_number")]
            public int RhsAccountNumber { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("active_subscription_id")]
            public string ActiveSubscriptionId { get; set; }

            [JsonProperty("locked")]
            public bool Locked { get; set; }

            [JsonProperty("permanently_deactivated")]
            public bool PermanentlyDeactivated { get; set; }

            [JsonProperty("received_ach_debit_locked")]
            public bool ReceivedAchDebitLocked { get; set; }

            [JsonProperty("drip_enabled")]
            public bool DripEnabled { get; set; }

            [JsonProperty("eligible_for_fractionals")]
            public bool EligibleForFractionals { get; set; }

            [JsonProperty("eligible_for_drip")]
            public bool EligibleForDrip { get; set; }

            [JsonProperty("eligible_for_cash_management")]
            public object EligibleForCashManagement { get; set; }

            [JsonProperty("cash_management_enabled")]
            public bool CashManagementEnabled { get; set; }

            [JsonProperty("option_trading_on_expiration_enabled")]
            public bool OptionTradingOnExpirationEnabled { get; set; }

            [JsonProperty("cash_held_for_options_collateral")]
            public string CashHeldForOptionsCollateral { get; set; }

            [JsonProperty("fractional_position_closing_only")]
            public bool FractionalPositionClosingOnly { get; set; }

            [JsonProperty("user_id")]
            public string UserId { get; set; }

            [JsonProperty("rhs_stock_loan_consent_status")]
            public string RhsStockLoanConsentStatus { get; set; }

            [JsonProperty("equity_trading_lock")]
            public string EquityTradingLock { get; set; }

            [JsonProperty("option_trading_lock")]
            public string OptionTradingLock { get; set; }
        }
   
}
