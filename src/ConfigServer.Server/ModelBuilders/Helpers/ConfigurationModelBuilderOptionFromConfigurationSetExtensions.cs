﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConfigServer.Server
{
    /// <summary>
    /// Property Option Builders For Configurations Set
    /// </summary>
    public static class ConfigurationModelBuilderOptionFromConfigurationSetExtensions
    {
        /// <summary>
        /// Gets ConfigurationPropertyModelBuilder for property with option
        /// Overides existing configuration from property
        /// </summary>
        /// <typeparam name="TModel">Source model type</typeparam>
        /// <typeparam name="TOption">Option type</typeparam>
        /// <typeparam name="TConfigurationSet">ConfigurationSet to provide available options</typeparam>
        /// <param name="source">model with property</param>
        /// <param name="expression">property selector</param>
        /// <param name="optionProvider">Options Selector</param>
        /// <returns>ConfigurationPropertyWithOptionBuilder for selected property</returns>
        public static ConfigurationPropertyWithConfigSetOptionBuilder PropertyWithConfigurationSetOptions<TModel, TOption, TConfigurationSet>(this IModelWithProperties<TModel> source, Expression<Func<TModel, TOption>> expression, Expression<Func<TConfigurationSet, OptionSet<TOption>>> optionProvider) where TConfigurationSet : ConfigurationSet
        {
            var propertyName = ExpressionHelper.GetPropertyNameFromExpression(expression);
            var optionName = ExpressionHelper.GetPropertyNameFromExpression(optionProvider);
            var model = new ConfigurationPropertyWithConfigSetOptionsModelDefinition<TConfigurationSet, TOption>(optionProvider.Compile(), optionName, propertyName, typeof(TModel));
            source.ConfigurationProperties[propertyName] = model;
            return new ConfigurationPropertyWithConfigSetOptionBuilder(model);
        }


        /// <summary>
        /// Gets ConfigurationPropertyModelBuilder for property with multiple option
        /// Overides existing configuration from property
        /// </summary>
        /// <typeparam name="TModel">Source model type</typeparam>
        /// <typeparam name="TOption">Option type</typeparam>
        /// <typeparam name="TOptionCollection">Option Collection type</typeparam>
        /// <typeparam name="TConfigurationSet">ConfigurationSet to provide available options</typeparam>
        /// <param name="source">model with property</param>
        /// <param name="expression">property selector</param>
        /// <param name="optionProvider">Options Selector</param>
        /// <returns>ConfigurationPropertyWithOptionBuilder for selected property</returns>
        public static ConfigurationPropertyWithConfigSetOptionBuilder PropertyWithMultipleConfigurationSetOptions<TModel, TOption, TOptionCollection, TConfigurationSet>(this IModelWithProperties<TModel> source, Expression<Func<TModel, TOptionCollection>> expression, Expression<Func<TConfigurationSet, OptionSet<TOption>>> optionProvider) where TConfigurationSet : ConfigurationSet where TOption : new() where TOptionCollection : ICollection<TOption>
        {
            var propertyName = ExpressionHelper.GetPropertyNameFromExpression(expression);
            var optionName = ExpressionHelper.GetPropertyNameFromExpression(optionProvider);
            var model = new ConfigurationPropertyWithMultipleConfigSetOptionsModelDefinition<TConfigurationSet, TOption, TOptionCollection>(optionProvider.Compile(), optionName, propertyName, typeof(TModel));
            source.ConfigurationProperties[propertyName] = model;
            return new ConfigurationPropertyWithConfigSetOptionBuilder(model);
        }
    }
}