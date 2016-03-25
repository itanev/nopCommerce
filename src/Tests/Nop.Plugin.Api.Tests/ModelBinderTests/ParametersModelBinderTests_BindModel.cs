﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http.ModelBinding;
using Nop.Plugin.Api.ModelBinders;
using Nop.Plugin.Api.Tests.ModelBinderTests.DummyObjects;
using NUnit.Framework;
using Rhino.Mocks;

namespace Nop.Plugin.Api.Tests.ModelBinderTests
{
    [TestFixture]
    public class ParametersModelBinderTests_BindModel
    {
        [Test]
        public void WhenRequestDoesNotContainQuery_BindingContextShouldContainInstanceOfTheModelType()
        {
            // Arrange
            var binder = new ParametersModelBinder<DummyModel>();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, "http://someUri");
            httpControllerContext.Request.Content = new ObjectContent(typeof(DummyModel), new DummyModel(), new XmlMediaTypeFormatter());

            var httpActionContext = new HttpActionContext();
            httpActionContext.ControllerContext = httpControllerContext;

            var bindingContext = new ModelBindingContext();
            var provider = MockRepository.GenerateStub<ModelMetadataProvider>();
            var metaData = new ModelMetadata(provider, null, null, typeof(DummyModel), null);
            bindingContext.ModelMetadata = metaData;

            //Act
            binder.BindModel(httpActionContext, bindingContext);

            // Assert
            Assert.IsInstanceOf<DummyModel>(bindingContext.Model);
        }

        [Test]
        public void WhenRequestContainsQueryWithValidIntProperty_BindingContextShouldContainInstanceOfTheModelTypeWithItsIntPropertySetToTheValue()
        {
            // Arrange
            var binder = new ParametersModelBinder<DummyModel>();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, "http://someUri");
            httpControllerContext.Request.Content = new ObjectContent(typeof(DummyModel), new DummyModel(), new XmlMediaTypeFormatter());

            httpControllerContext.Request.Properties.Add("MS_QueryNameValuePairs", new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("int_property", "5")
            });

            var httpActionContext = new HttpActionContext();
            httpActionContext.ControllerContext = httpControllerContext;

            var bindingContext = new ModelBindingContext();
            var provider = MockRepository.GenerateStub<ModelMetadataProvider>();
            var metaData = new ModelMetadata(provider, null, null, typeof(DummyModel), null);
            bindingContext.ModelMetadata = metaData;

            //Act
            binder.BindModel(httpActionContext, bindingContext);

            // Assert
            Assert.AreEqual(5, ((DummyModel)bindingContext.Model).IntProperty);
        }

        [Test]
        public void WhenRequestContainsQueryWithValidStringProperty_BindingContextShouldContainInstanceOfTheModelTypeWithItsStringPropertySetToTheValue()
        {
            // Arrange
            var binder = new ParametersModelBinder<DummyModel>();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, "http://someUri");
            httpControllerContext.Request.Content = new ObjectContent(typeof(DummyModel), new DummyModel(), new XmlMediaTypeFormatter());

            httpControllerContext.Request.Properties.Add("MS_QueryNameValuePairs", new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("string_property", "some value")
            });

            var httpActionContext = new HttpActionContext();
            httpActionContext.ControllerContext = httpControllerContext;

            var bindingContext = new ModelBindingContext();
            var provider = MockRepository.GenerateStub<ModelMetadataProvider>();
            var metaData = new ModelMetadata(provider, null, null, typeof(DummyModel), null);
            bindingContext.ModelMetadata = metaData;

            //Act
            binder.BindModel(httpActionContext, bindingContext);

            // Assert
            Assert.AreEqual("some value", ((DummyModel)bindingContext.Model).StringProperty);
        }

        [Test]
        public void WhenRequestContainsQueryWithValidDateTimeProperty_BindingContextShouldContainInstanceOfTheModelTypeWithItsDateTimePropertySetToTheValue()
        {
            // Arrange
            var binder = new ParametersModelBinder<DummyModel>();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, "http://someUri");
            httpControllerContext.Request.Content = new ObjectContent(typeof(DummyModel), new DummyModel(), new XmlMediaTypeFormatter());

            httpControllerContext.Request.Properties.Add("MS_QueryNameValuePairs", new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("date_time_nullable_property", "2016-12-12")
            });

            var httpActionContext = new HttpActionContext();
            httpActionContext.ControllerContext = httpControllerContext;

            var bindingContext = new ModelBindingContext();
            var provider = MockRepository.GenerateStub<ModelMetadataProvider>();
            var metaData = new ModelMetadata(provider, null, null, typeof(DummyModel), null);
            bindingContext.ModelMetadata = metaData;

            //Act
            binder.BindModel(httpActionContext, bindingContext);

            // Assert
            Assert.AreEqual(new DateTime(2016, 12, 12), ((DummyModel)bindingContext.Model).DateTimeNullableProperty.Value);
        }

        [Test]
        public void WhenRequestContainsQueryWithValidBooleanStatusProperty_BindingContextShouldContainInstanceOfTheModelTypeWithItBooleanStatusPropertySetToTheValue()
        {
            // Arrange
            var binder = new ParametersModelBinder<DummyModel>();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, "http://someUri");
            httpControllerContext.Request.Content = new ObjectContent(typeof(DummyModel), new DummyModel(), new XmlMediaTypeFormatter());

            httpControllerContext.Request.Properties.Add("MS_QueryNameValuePairs", new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("boolean_nullable_status_property", "published")
            });

            var httpActionContext = new HttpActionContext();
            httpActionContext.ControllerContext = httpControllerContext;

            var bindingContext = new ModelBindingContext();
            var provider = MockRepository.GenerateStub<ModelMetadataProvider>();
            var metaData = new ModelMetadata(provider, null, null, typeof(DummyModel), null);
            bindingContext.ModelMetadata = metaData;

            //Act
            binder.BindModel(httpActionContext, bindingContext);

            // Assert
            Assert.AreEqual(true, ((DummyModel)bindingContext.Model).BooleanNullableStatusProperty.Value);
        }

        [Test]
        public void BindModel_ShouldAlwaysReturnTrue()
        {
            // Arrange
            var binder = new ParametersModelBinder<DummyModel>();
            var httpControllerContext = new HttpControllerContext();
            httpControllerContext.Request = new HttpRequestMessage(HttpMethod.Get, "http://someUri");
            httpControllerContext.Request.Content = new ObjectContent(typeof(DummyModel), new DummyModel(), new XmlMediaTypeFormatter());
            
            var httpActionContext = new HttpActionContext();
            httpActionContext.ControllerContext = httpControllerContext;

            var bindingContext = new ModelBindingContext();
            var provider = MockRepository.GenerateStub<ModelMetadataProvider>();
            var metaData = new ModelMetadata(provider, null, null, typeof(DummyModel), null);
            bindingContext.ModelMetadata = metaData;

            //Act
            bool result = binder.BindModel(httpActionContext, bindingContext);

            // Assert
            Assert.IsTrue(result);
        }
    }
}