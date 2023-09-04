using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model;
using GeekShopping.CartAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public CartRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartVO> FindCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(long cartDetailsId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartVO> SaveOrUpdateCart(CartVO cartVO)
        {
            Cart cart = _mapper.Map<Cart>(cartVO);
            
            //Check if the product is already saved in the database if it does not exist the save
            var product = await _context.Products.FirstOrDefaultAsync(p =>
                p.Id == cartVO.Details.FirstOrDefault().ProductId);
            
            if (product == null)
            {
                _context.Products.Add(cart.Details.FirstOrDefault().Product);
                await _context.SaveChangesAsync();
            }

            //Check if CartHearder is null
            var cartHeader = await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(c =>
                c.UserId == cart.CartHeader.UserId);
            if (cartHeader == null)
            {
                //Create CartHeader and CartDetails
                _context.CartHeaders.Add(cart.CartHeader);
                await _context.SaveChangesAsync();

                cart.Details.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.Details.FirstOrDefault().Product = null;
                _context.CartDetails.Add(cart.Details.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
            else
            {
                //If CartHeader is not null
                //Check if CartDetails has same product
                var cartDetail = await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(p =>
                        p.ProductId == cartVO.Details.FirstOrDefault().ProductId &&
                        p.CartHeaderId == cartHeader.Id);
                if(cartDetail == null)
                {
                    //Create CartDetails
                    cart.Details.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                    cart.Details.FirstOrDefault().Product = null;
                    _context.CartDetails.Add(cart.Details.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //Update product count and CartDetails
                    cart.Details.FirstOrDefault().Product = null;
                    cart.Details.FirstOrDefault().Count += cartDetail.Count;
                    cart.Details.FirstOrDefault().Id = cartDetail.Id;
                    cart.Details.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                    _context.CartDetails.Update(cart.Details.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
            }
            return _mapper.Map<CartVO>(cart);

            throw new NotImplementedException();
        }
    }
}
