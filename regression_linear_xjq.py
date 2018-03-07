# -*- coding: utf-8-sig -*-

#import os
import sys
import numpy as np
import pandas as pd
import pyodbc
from pandas import DataFrame


#打开参数文件
conn = pyodbc.connect(r'DRIVER={SQL Server};SERVER=192.168.191.1,1433;DATABASE=pro;uid=11223344;pwd=123456')
cursor =conn.cursor()
filename_param = 'data//tmp.csv'
df_param = pd.read_csv(filename_param,header=None,encoding='utf-8-sig')
data_param = df_param.values
i =0
test_append = 'select '
while i< data_param.size:
    if i==0:
        test_append +=data_param[i][0]
        i+=1
    else:
        test_append +=","+data_param[i][0]
        i+=1
#为了这个有变量的sql语句，贫道可是费了一番功夫xjq
test_append +=' from pro.dbo.Project_Iron'
cursor.execute(test_append)
rows = cursor.fetchall()
cursor.close()

data1 =np.array(rows)
#数据源文件名
#filename = 'data_multivar.csv'
########################################
#读入csv文件,并处理缺失值,并得到自变量和因变量值
#df = pd.read_csv(filename,header=None,encoding='utf-8-sig')
#clearned = df.dropna()
#data = clearned.values
dd = DataFrame(data1)
clearned = dd.dropna()
data1 = np.array(clearned)
''''
在将dataframe转化为 array
'''
X,y = data1[:,:-1],data1[:,-1]
#########################################
# Train test split
from sklearn import cross_validation
X_train, X_test, y_train, y_test = cross_validation.train_test_split(X, y, test_size=0.2, random_state=5)


# Create linear regression object
from sklearn import linear_model
linear_regressor = linear_model.LinearRegression()
ridge_regressor = linear_model.Ridge(alpha=0.01, fit_intercept=True, max_iter=5)

# Polynomial regression
from sklearn.preprocessing import PolynomialFeatures

# Train the model using the training sets
linear_regressor.fit(X_train, y_train)
ridge_regressor.fit(X_train, y_train)

polynomial = PolynomialFeatures(degree=3)  #三次多项式
X_train_transformed = polynomial.fit_transform(X_train)
poly_linear_model = linear_model.LinearRegression()
poly_linear_model.fit(X_train_transformed, y_train)

# Stochastic Gradient Descent regressor
sgd_regressor = linear_model.SGDRegressor(loss='huber', n_iter=50)
sgd_regressor.fit(X_train, y_train)

# Predict the output
y_test_pred = linear_regressor.predict(X_test)
y_test_pred_ridge = ridge_regressor.predict(X_test)

X_test_transformed = polynomial.fit_transform(X_test)
y_test_pred_ploy = poly_linear_model.predict(X_test_transformed)
y_test_pred_sgd = sgd_regressor.predict(X_test)

# Measure performance
import sklearn.metrics as sm

print ("LINEAR REGRESSIONER :")
#writer.writerow(["LINEAR REGRESSIONER :"])
#writer.writerow(["Mean absolute error","Mean squared error","Median absolute error","Explained variance score","R2 score","Linear regression coefficents"])
#writer.writerows([[0,1,3],[1,2,3],[2,3,4]])
print ( "Mean absolute error =", round(sm.mean_absolute_error(y_test, y_test_pred), 2) )
print ("Mean squared error =", round(sm.mean_squared_error(y_test, y_test_pred), 2) )
print ("Median absolute error =", round(sm.median_absolute_error(y_test, y_test_pred), 2) )
print ("Explained variance score =", round(sm.explained_variance_score(y_test, y_test_pred), 2) )
print ("R2 score =", round(sm.r2_score(y_test, y_test_pred), 2))
print("Linear regression coefficents:",linear_regressor.coef_)

print ("\nRIDGE LINEAR REGRESSIONER :")
print ( "Mean absolute error =", round(sm.mean_absolute_error(y_test, y_test_pred_ridge), 2) )
print ("Mean squared error =", round(sm.mean_squared_error(y_test, y_test_pred_ridge), 2) )
print ( "Median absolute error =", round(sm.median_absolute_error(y_test, y_test_pred_ridge), 2) )
print ("Explained variance score =", round(sm.explained_variance_score(y_test, y_test_pred_ridge), 2) )
print ("R2 score =", round(sm.r2_score(y_test, y_test_pred_ridge), 2))
print("Ridge linear  regression coefficents:",ridge_regressor.coef_)

print ("\nPOLY REGRESSIONER :")
print ( "Mean absolute error =", round(sm.mean_absolute_error(y_test, y_test_pred_ploy), 2) )
print ("Mean squared error =", round(sm.mean_squared_error(y_test, y_test_pred_ploy), 2) )
print ( "Median absolute error =", round(sm.median_absolute_error(y_test, y_test_pred_ploy), 2) )
print ("Explained variance score =", round(sm.explained_variance_score(y_test, y_test_pred_ploy), 2) )
print ("R2 score =", round(sm.r2_score(y_test, y_test_pred_ploy), 2))
#print("Poly  regression coefficents:",poly_linear_model.coef_)

print ("\nStochastic Gradient Descent regressor :")
print ( "Mean absolute error =", round(sm.mean_absolute_error(y_test, y_test_pred_sgd), 2) )
print ("Mean squared error =", round(sm.mean_squared_error(y_test, y_test_pred_sgd), 2) )
print ( "Median absolute error =", round(sm.median_absolute_error(y_test, y_test_pred_sgd), 2) )
print ("Explained variance score =", round(sm.explained_variance_score(y_test, y_test_pred_sgd), 2) )
print ("R2 score =", round(sm.r2_score(y_test, y_test_pred_sgd), 2))


###############
#模型使用
list_a = []
i = 0
#读取将要预测的值
filename = 'data//test_data.csv'
test_data = pd.read_csv(filename,header=None,encoding='utf-8-sig')
datapoint = test_data.values
#datapoint = np.array([0.39,2.78,7.11]).reshape(1,-1)   #wyy修改

print ("\nLinear regression:\n", linear_regressor.predict(datapoint)[0])
print ("\nLinear Ridge regression:\n", ridge_regressor.predict(datapoint)[0])

poly_datapoint = polynomial.fit_transform(datapoint)
print ("\nPolynomial regression:\n", poly_linear_model.predict(poly_datapoint)[0])

print ( "\nSGD regressor:\n", sgd_regressor.predict(datapoint))


