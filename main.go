package main

import (
	"fmt"
	"log"
	"net/http"
	"os"
	"os/signal"
	"syscall"
)

func ProductHandler(w http.ResponseWriter, r *http.Request) {
	// Extract the "id" parameter from the URL path
	id := r.URL.Path[len("/api/product/"):]

	imageUrl := ""
	// test general id that dictates the state of the marketing module
	if id != "000000" {
		imageUrl = customerMarketingAlgorithm()
	} else {
		imageUrl = generalMarketingAlgorithm()
	}

	// Prepare the HTML response with an image (and id temporarily for testing purposes)
	htmlResponse := fmt.Sprintf(`<html><body><h1>Customer ID: %s</h1><img src="%s"></body></html>`, id, imageUrl)

	// Set the content type to HTML
	w.Header().Set("Content-Type", "text/html")

	// Write the HTML response to the client
	w.Write([]byte(htmlResponse))
}

// this would be the path the code takes if the general user id is provided
func generalMarketingAlgorithm() string {
	fmt.Printf("generalMarketingAlgorithm called\n")

	//the image url would be a dynamic image src gathered from the algorithm (and database if required) returning the correct image for the ad spot
	imageUrl := "https://picsum.photos/200/300"
	return imageUrl
}

// this would be the path the code takes if the customer user id is provided
func customerMarketingAlgorithm() string {
	fmt.Printf("customerMarketingAlgorithm called\n")

	//the image url would be a dynamic image src gathered from the algorithm (and database if required) returning the correct image for the ad spot
	imageUrl := "https://picsum.photos/200/300"
	return imageUrl
}

func main() {
	fmt.Printf("Starting server at port 8080\n")
	server := &http.Server{Addr: ":8080"}

	// the process to determine whether marketing should be general or targeted will be the same for each route
	http.HandleFunc("/api/product/", ProductHandler)

	go func() {
		if err := server.ListenAndServe(); err != nil && err != http.ErrServerClosed {
			log.Fatalf("Listen: %s\n", err)
		}
	}()

	// Create a channel to wait for a termination signal
	c := make(chan os.Signal, 1)
	signal.Notify(c, os.Interrupt, syscall.SIGTERM)

	// Block until a signal is received
	<-c

	fmt.Println("Shutting down the server...")
	server.Shutdown(nil)
	fmt.Println("Server is gracefully stopped.")
}
