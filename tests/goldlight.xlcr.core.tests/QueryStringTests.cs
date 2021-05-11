﻿using System;
using Xunit;

namespace Goldlight.Xlcr.Core.Tests
{
  public class QueryStringTests
  {
    [Fact]
    public void GivenQueryStringWhenAddingKeyValuePairs_WithKeyAndValue_ThenNoExceptionIsThrown()
    {
      QueryString queryString = new QueryString();
      Exception capturedException = Record.Exception(() => queryString.Add("key", "value"));
      Assert.Null(capturedException);
    }

    [Fact]
    public void GivenQueryStringWhenAddingKeyValuePairs_WithNoKey_ThenArgumentExceptionIsThrown()
    {
      QueryString queryString = new QueryString();
      Assert.Throws<ArgumentException>(() => queryString.Add(string.Empty, "value"));
    }

    [Fact]
    public void GivenQueryStringWhenAddingKeyValuePairs_WithNoValue_ThenArgumentExceptionIsThrown()
    {
      QueryString queryString = new QueryString();
      Assert.Throws<ArgumentException>(() => queryString.Add("key", string.Empty));
    }

    [Fact]
    public void GivenCallToTransformWhenUrlPassedIn_WithNoKeyValuePairs_ThenOriginalUrlIsReturned()
    {
      QueryString queryString = new QueryString();
      Assert.Equal("https://pete.dummyapi.com/get/", queryString.Transform("https://pete.dummyapi.com/get/"));
    }
  }
}
