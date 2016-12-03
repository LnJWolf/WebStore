using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebStore.BusinessLogic.Services.Base;
using WebStore.DataAccess.Repositories.Base;
using WebStore.Domain.Entities;
using System.Web.Mvc;
using WebStore.BusinessLogic.DTO;
using WebStore.BusinessLogic.DTO.Product;

namespace WebStore.BusinessLogic.Services
{
    public class ProductService
        : IProductService
    {
        IProductRepository _productRepository = null;
        ICategoryRepository _categoryRepository = null;
        IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return _categoryRepository.GetCategories().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToArray();
        }

        public IEnumerable<Product/*ViewModel*/> GetProducts(ProductFilter filter = null)
        {
            if (filter == null || filter.IsEmpty)
            {

                var productArray = _productRepository.GetProducts().ToArray();
                //var convertedArray = new List<ProductViewModel>();
                //foreach (var prod in productArray)
                //{
                //    convertedArray.Add(_mapper.Map<ProductViewModel>(prod));
                //}
                //return convertedArray;
                return productArray;
            }

            var products = _productRepository.GetProductsAsQueryable();

            products = products.Where(x => x.Name.Trim().ToLower() == filter.Name.Trim().ToLower());

            var filteredArray = products.ToArray();
            //var convertedFilteredArray = new List<ProductViewModel>();
            //foreach (var prod in filteredArray)
            //{
            //    convertedFilteredArray.Add(_mapper.Map<ProductViewModel>(prod));
            //}
            //return convertedFilteredArray;
            return filteredArray;
        }

        public IEnumerable<Product/*ViewModel*/> GetProductsByIDs(IEnumerable<int> IDs)
        {
            var convertedArray = new List<Product/*ViewModel*/>();

            foreach (int id in IDs)
            {
                convertedArray.Add(/*_mapper.Map<ProductViewModel>(*/_productRepository.GetProductWithCategory(id))/*)*/;
            }

            return convertedArray;
        }

        public void UpdateProduct(ProductViewModel viewModel)
        {
            var product = _mapper.Map<Product>(viewModel);

            if (product.Id != 0)
            {
                var oldProduct = _productRepository.GetProduct(product.Id);

                oldProduct.Name = product.Name;
                oldProduct.Description = product.Description;
                oldProduct.CategoryId = product.CategoryId;
                oldProduct.IsDeleted = product.IsDeleted;
            }
            else if (product.Id == 0)
            {
                _productRepository.AddProduct(product);
            }

            _productRepository.SaveChanges();
        }

        public void RemoveProduct(int id)
        {
            var prod = _productRepository.GetProduct(id);

            if (prod != null)
            {
                _productRepository.RemoveProduct(prod);
            }
        }

        public ProductViewModel GetProduct(int id)
        {
            var prod = _productRepository.GetProduct(id);

            return _mapper.Map<ProductViewModel>(prod);
        }
    }
}
