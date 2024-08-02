namespace FinanceBuddyAPI.Models
{
    /// <summary>
    /// Implements the ITransaction interface.
    /// </summary>
    public class Transaction : ITransaction
    {
        #region Properties

        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string? Name { get; set; }

        /// <inheritdoc/>
        public decimal Amount { get; set; }

        /// <inheritdoc/>
        public DateTime TransactionDate { get; set; }

        #endregion
    }
}
