using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Retete.Data;
using Retete.Models;

namespace Retete.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly Retete.Data.ReteteContext _context;

        public IndexModel(Retete.Data.ReteteContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Member != null)
            {
                Member = (IList<Member>)await _context.Member.ToListAsync();
            }
        }
    }
}
