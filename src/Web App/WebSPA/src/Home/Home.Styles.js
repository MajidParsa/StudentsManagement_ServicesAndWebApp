const homeStyles = {
    body:{
        minHeight: "100%",
        display: "flex",
        flexDirection: "column",
    },
    header: {
        backgroundColor: "gray",
        height: 60,
        display: "flex",
        flexDirection: "row-reverse",        
        justifyContent: "space-between",
        alignItems: "center",
    },
    main: {
        backgroundColor: "#f00",
        color: "#fff",
        flex: 1,
        display: "flex",        
        justifyContent: "center",
        alignItems: "center"
    },
    footer:{
        backgroundColor: "#F0f",
        height: 40
    },
    right:{
        backgroundColor: "#FFF",
        height: 10,
        width: 100,
    },
    center:{
        backgroundColor: "#00F",
        height: 10,
        width: 350,
    },
    left:{
        backgroundColor: "#0f0",
        height: 10,
        width: 60,
    },
    form:{
        height: 400,
        width: 400,
        backgroundColor: "#FFF",
        borderRadius: 10,
        boxShadow: "2px 2px 10px #000"
    }
}

export default homeStyles