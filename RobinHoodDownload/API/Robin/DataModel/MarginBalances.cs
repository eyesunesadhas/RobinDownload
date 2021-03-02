using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.API.Robin.DataModel
{
    public class MarginBalances
    {
        [JsonProperty("uncleared_deposits")]
        public string UnclearedDeposits { get; set; }

        [JsonProperty("cash")]
        public string Cash { get; set; }

        [JsonProperty("cash_held_for_dividends")]
        public string CashHeldForDividends { get; set; }

        [JsonProperty("cash_held_for_restrictions")]
        public string CashHeldForRestrictions { get; set; }

        [JsonProperty("cash_held_for_nummus_restrictions")]
        public string CashHeldForNummusRestrictions { get; set; }

        [JsonProperty("cash_held_for_orders")]
        public string CashHeldForOrders { get; set; }

        [JsonProperty("cash_available_for_withdrawal")]
        public string CashAvailableForWithdrawal { get; set; }

        [JsonProperty("unsettled_funds")]
        public string UnsettledFunds { get; set; }

        [JsonProperty("unsettled_debit")]
        public string UnsettledDebit { get; set; }

        [JsonProperty("outstanding_interest")]
        public string OutstandingInterest { get; set; }

        [JsonProperty("unallocated_margin_cash")]
        public string UnallocatedMarginCash { get; set; }

        [JsonProperty("margin_limit")]
        public string MarginLimit { get; set; }

        [JsonProperty("crypto_buying_power")]
        public string CryptoBuyingPower { get; set; }

        [JsonProperty("day_trade_buying_power")]
        public string DayTradeBuyingPower { get; set; }

        [JsonProperty("sma")]
        public string Sma { get; set; }

        [JsonProperty("day_trades_protection")]
        public bool DayTradesProtection { get; set; }

        [JsonProperty("start_of_day_overnight_buying_power")]
        public string StartOfDayOvernightBuyingPower { get; set; }

        [JsonProperty("overnight_buying_power")]
        public string OvernightBuyingPower { get; set; }

        [JsonProperty("overnight_buying_power_held_for_orders")]
        public string OvernightBuyingPowerHeldForOrders { get; set; }

        [JsonProperty("day_trade_buying_power_held_for_orders")]
        public string DayTradeBuyingPowerHeldForOrders { get; set; }

        [JsonProperty("overnight_ratio")]
        public string OvernightRatio { get; set; }

        [JsonProperty("day_trade_ratio")]
        public string DayTradeRatio { get; set; }

        [JsonProperty("marked_pattern_day_trader_date")]
        public string MarkedPatternDayTraderDate { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("start_of_day_dtbp")]
        public string StartOfDayDtbp { get; set; }

        [JsonProperty("portfolio_cash")]
        public string PortfolioCash { get; set; }

        [JsonProperty("cash_held_for_options_collateral")]
        public string CashHeldForOptionsCollateral { get; set; }

        [JsonProperty("gold_equity_requirement")]
        public string GoldEquityRequirement { get; set; }

        [JsonProperty("uncleared_nummus_deposits")]
        public string UnclearedNummusDeposits { get; set; }

        [JsonProperty("cash_pending_from_options_events")]
        public string CashPendingFromOptionsEvents { get; set; }

        [JsonProperty("settled_amount_borrowed")]
        public string SettledAmountBorrowed { get; set; }

        [JsonProperty("pending_deposit")]
        public string PendingDeposit { get; set; }

        [JsonProperty("funding_hold_balance")]
        public string FundingHoldBalance { get; set; }

        [JsonProperty("pending_debit_card_debits")]
        public string PendingDebitCardDebits { get; set; }

        [JsonProperty("net_moving_cash")]
        public string NetMovingCash { get; set; }

        [JsonProperty("margin_withdrawal_limit")]
        public object MarginWithdrawalLimit { get; set; }

        [JsonProperty("instant_used")]
        public string InstantUsed { get; set; }

        [JsonProperty("instant_allocated")]
        public string InstantAllocated { get; set; }

        [JsonProperty("eligible_deposit_as_instant")]
        public string EligibleDepositAsInstant { get; set; }
    }

}
