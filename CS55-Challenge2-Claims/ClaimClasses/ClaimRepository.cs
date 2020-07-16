using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimClasses
{
    public class ClaimRepository
    {
        private readonly List<Claim> _repo = new List<Claim>();
        
        public bool AddClaimToDatabase(Claim claim)
        {
            int prevCount = _repo.Count;
            _repo.Add(claim);
            return (_repo.Count > prevCount);
        }

        public List<Claim> GetClaims()
        {
            return _repo;
        }

        public Claim GetClaimByID(int ID)
        {
            foreach (Claim item in _repo)
            {
                if (item.ClaimID == ID)
                {
                    return item;
                }
            }

            return null;
        }

        public bool DeleteClaim(Claim claim)
        {
            return _repo.Remove(claim);
        }
    }
}
