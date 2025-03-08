from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.chrome.service import Service
from selenium.common.exceptions import NoSuchElementException
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

from webdriver_manager.chrome import ChromeDriverManager

from bs4 import BeautifulSoup as BS
from datetime import datetime

import random
import pandas as pd
import time
import sys, os
import re
import json
import math

def find_xpath(xpath, browser):
    return browser.find_element(By.XPATH, xpath)
def finds_xpath(xpath, browser):
    return browser.find_elements(By.XPATH, xpath)

def find_id(e_id, browser):
    return browser.find_element(By.ID, e_id)

def find_className(cn, browser):
    return browser.find_element(By.CLASS_NAME, cn)
def finds_className(cn , browser):
    return browser.find_elements(By.CLASS_NAME, cn )

def find_name(name, browser):
    return browser.find_element(By.NAME, name)
def finds_name(name, browser):
    return browser.find_elements(By.NAME, name)

def is_nan(value):
    return isinstance(value, float) and math.isnan(value)

def open_browser():
    options = Options()
    options.add_argument('--no-sandbox')
    options.add_argument('--disable-dev-shm-usage')
    options.add_argument('--window-size=1080,800')
    options.add_argument('incognito')

    # Use the ChromeDriver in the specified path
    chrome_service = Service("C:\\Users\\*\\*\\chromedriver.exe") # Update the path to where chromedriver.exe is located
    browser = webdriver.Chrome(service=chrome_service, options=options)

    return browser

# Load the Excel file
file_path = ("C:\\Users\\*\\*\\insta_auto_dm_contents.xlsx")
df = pd.read_excel(file_path)

print(df.columns)

def open_url(browser, url):
    browser.get(url)
    time.sleep(.5)

url = "instagram-address"

# Open the browser
browser = open_browser()
open_url(browser, url)

# Login - Id
login_id = 'your-id'
# Login - Pw
login_pw = 'your-password'


def login_page_field(browser, login_id, login_pw):

    # Login - Id
    if find_xpath('/html/body/div[1]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/article/div[2]/div[1]/div[2]/div/form/div[1]/div[1]/div/label/input', browser).get_attribute('value') == "":
        find_xpath('/html/body/div[1]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/article/div[2]/div[1]/div[2]/div/form/div[1]/div[1]/div/label/input', browser).send_keys(login_id)
    # Login - Pw
    if find_xpath('/html/body/div[1]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/article/div[2]/div[1]/div[2]/div/form/div[1]/div[2]/div/label/input', browser).get_attribute('value') == "":
        find_xpath('/html/body/div[1]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/article/div[2]/div[1]/div[2]/div/form/div[1]/div[2]/div/label/input', browser).send_keys(login_pw)
    # Login - Button
    find_xpath('/html/body/div[1]/div/div/div[2]/div/div/div[1]/div[1]/div/section/main/article/div[2]/div[1]/div[2]/div/form/div[1]/div[3]/button', browser).click()

login_page_field(browser, login_id, login_pw)    


def auto_dm__field(browser, receiver_name, content_list):

    time.sleep(0.5)
    find_xpath('/html/body/div[1]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/div/div/div/div/div[2]/div[5]/div/div/span/div/a/div', browser).click()
    time.sleep(0.5)
    find_xpath('/html/body/div[1]/div/div/div[2]/div/div/div[1]/div[1]/div[1]/section/main/section/div/div/div/div[1]/div/div[2]/div/div/div/div[4]/div', browser).click()

    # Input Receiver
    if find_xpath('/html/body/div[7]/div[1]/div/div[2]/div/div/div/div/div/div/div[1]/div/div[2]/div/div[2]/input', browser).get_attribute('value') == "":
        find_xpath('/html/body/div[7]/div[1]/div/div[2]/div/div/div/div/div/div/div[1]/div/div[2]/div/div[2]/input', browser).send_keys(receiver_name)
    # Select Receiver
    time.sleep(1)
    find_xpath('/html/body/div[7]/div[1]/div/div[2]/div/div/div/div/div/div/div[1]/div/div[3]/div/div[1]/div[1]/div/div/div[3]/div/label/div/input', browser).click()
    # Click Button "Chat"
    time.sleep(1)
    find_xpath('/html/body/div[7]/div[1]/div/div[2]/div/div/div/div/div/div/div[1]/div/div[4]/div', browser).click()
    # Input Content
    time.sleep(3)
    find_xpath('/html/body/div[1]/div/div/div[2]/div/div/div[1]/div[1]/div[1]/section/main/section/div/div/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div[3]/div/div/div[2]/div/div[1]/p', browser).send_keys(content_list)
    # Click Button "Chat"
    time.sleep(1)
    find_xpath('/html/body/div[1]/div/div/div[2]/div/div/div[1]/div[1]/div[1]/section/main/section/div/div/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div[3]/div/div/div[3]', browser).click()


# Loop through each row in the DataFrame
for index, row in df.iterrows():
    # Receiver
    receiver_name = row['NAME']
    # Content
    content_list = row['CONTENT']
    
    # Process the page fields for this row
    auto_dm__field(browser, receiver_name, content_list)

    # Before executing next row, add delay
    time.sleep(1)
                  
# Print this after loop every row
print("All rows processed.")

