using Microsoft.AspNetCore.Mvc;
using FinanceBuddyAPI.Models;

namespace FinanceBuddy
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetController : ControllerBase
    {
        #region Mock Data

        /// <summary>
        /// A list of mock transactions to use as test data.
        /// </summary>
        private static readonly List<ITransaction> MockItems =
        [
            new Transaction{Id=1, Name="Rent", Amount=1200, TransactionDate=DateTime.Now.AddMonths(-1)},
            new Transaction{Id=2, Name="Groceries", Amount=200, TransactionDate=DateTime.Now.AddMonths(-1)}
        ];

        #endregion

        #region Public Methods

        [HttpPost]
        public IActionResult Create([FromBody] Transaction newTransaction)
        {
            if (newTransaction == null)
            {
                return BadRequest();
            }

            // Generate a new ID
            newTransaction.Id = MockItems.Max(t => t.Id) + 1;
            MockItems.Add(newTransaction);

            return CreatedAtAction(nameof(Get), new { id = newTransaction.Id }, newTransaction);
        }

        /// <summary>
        /// Gets all transaction data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ITransaction> Get()
        {
            return MockItems;
        }

        /// <summary>
        /// Gets a specific data object by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ITransaction> Get(int id)
        {
            var item = MockItems.FirstOrDefault(x => x.Id == id);
            if (item == null) 
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Updates a specific data object by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ITransaction item) 
        {
            var existingItem = MockItems.FirstOrDefault(x => x.Id == id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = item.Name;
            existingItem.Amount = item.Amount;
            existingItem.TransactionDate = item.TransactionDate;
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific data object by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var item = MockItems.FirstOrDefault(x => x.Id==id);

            if (item == null) 
            {
                return NotFound();
            }

            MockItems.Remove(item);
            return NoContent();
        }

        #endregion
    }
}